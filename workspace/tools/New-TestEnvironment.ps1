<#
.SYNOPSIS
    Builds a fresh git repository whose branches are exactly the requested test
    branches, each squashed into a single commit with no prior history.

.DESCRIPTION
    Run from anywhere in the source repo. All source branches are imported with
    a refspec fetch (not `git clone`, which only creates one local branch), then
    every requested branch is re-created as an orphan root commit and renamed in
    place. Non-requested branches are removed and all reflog/unreachable objects
    are purged so the output repo exposes no original history.

.EXAMPLE
    ./workspace/tools/New-TestEnvironment.ps1 -Output C:\tmp\AItest-TestEnv
#>
[CmdletBinding()]
param(
    [string]$Source = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path,

    [Parameter(Mandatory = $true)]
    [string]$Output,

    [string[]]$Branches = @(
        'docs',
        'test1', 'test2', 'test3', 'test4', 'test5',
        'test6', 'test7', 'test8', 'test9', 'test10'
    )
)

$ErrorActionPreference = 'Stop'

# --- Validate inputs ---------------------------------------------------------
if (-not (Test-Path -LiteralPath $Source -PathType Container)) {
    throw "Source repository not found: $Source"
}
if (-not (git -C $Source rev-parse --is-inside-work-tree 2>$null)) {
    throw "Source is not a git repository: $Source"
}
if (Test-Path -LiteralPath $Output) {
    throw "Output path already exists: $Output"
}

# --- Create the fresh repository --------------------------------------------
New-Item -ItemType Directory -Path $Output | Out-Null
git -C $Output init --quiet

# Committing needs an identity; scope it to this new repository only.
git -C $Output config user.name 'Test Environment'
git -C $Output config user.email 'test-environment@example.invalid'

# Import EVERY source branch as a local branch (do NOT use a clone).
git -C $Output fetch --quiet --update-head-ok $Source '+refs/heads/*:refs/heads/*'

# --- Squash each requested branch down to a single root commit ---------------
$processed = New-Object System.Collections.Generic.List[string]
foreach ($branch in $Branches) {
    git -C $Output show-ref --verify --quiet "refs/heads/$branch"
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Branch '$branch' not found in source; skipping."
        continue
    }

    git -C $Output checkout --quiet $branch
    git -C $Output checkout --quiet --orphan "__single_$branch"
    git -C $Output add -A
    git -C $Output commit --quiet --allow-empty -m "${branch}: single test environment"
    git -C $Output branch -D --quiet $branch
    git -C $Output branch -m $branch

    $processed.Add($branch)
}

if ($processed.Count -eq 0) {
    throw 'None of the requested branches exist in the source repository.'
}

# --- Remove every branch that was not requested ------------------------------
$keep = [System.Collections.Generic.HashSet[string]]::new(
    [string[]]$Branches,
    [System.StringComparer]::Ordinal
)
$existing = git -C $Output for-each-ref --format='%(refname:short)' refs/heads
foreach ($name in $existing) {
    if (-not $keep.Contains($name)) {
        git -C $Output branch -D --quiet $name
    }
}

# --- Leave the repository on the first requested branch ----------------------
git -C $Output checkout --quiet $Branches[0]

# --- Purge reflog and unreachable objects so no original history remains -----
git -C $Output reflog expire --expire=now --all
git -C $Output gc --prune=now --quiet

# --- Verify each branch has exactly one commit -------------------------------
foreach ($branch in $Branches) {
    $count = [int](git -C $Output rev-list --count $branch)
    Write-Host ('{0}: {1} commit(s)' -f $branch, $count)
    if ($count -ne 1) {
        throw "Branch '$branch' has $count commits; expected exactly 1."
    }
}

Write-Host "Done. Test environment created at: $Output"
