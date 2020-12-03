# Git Basics

## Goals

Understanding of:
- History of version control systems and how git differs
- Basic git repository commands
- Merging and resolving conflicts
- How to resolve common git errors
- "Trunk"/"Master" development.

## Content

### History

A non-exhaustive list of the progression of change tracking(SCM) software:

- RCS - Client/server
- CVS - Client/server
- Subversion(SVN) - Client/server

- Mercurial(Hg) - Distributed
- Git - Distributed

### So, why did git 'win'?

Asking most developers, it really shouldn't have. It has a terrible user experience.

A critical mass and the advent of GitHub pushed it ahead of mercurial, a DVCS released in the same week as Git.

### Principles

- Git was designed firstly as a filesystem by Linus Torvalds, creator and lead on the Linux Kernel

Has five main components:

- Blob
- Tree
- Commit
- Tag
- Packfile

### Everyday commands

- `git init` (maybe not everyday)

- `git commit`
- `git status`
- `git pull`
- `git push`
- `git add`

### Merging

- `git pull` does a merge:
- `git fetch && git merge FETCH_HEAD`

### Conflicts 

#### Resolving with GUI tools

- VsCode
- GitKraken
- TortoiseGit
- Visual Studio
- Git Extensions

### Resolving Common errors

- https://ohshitgit.com/

### Other resources

- https://learngitbranching.js.org/