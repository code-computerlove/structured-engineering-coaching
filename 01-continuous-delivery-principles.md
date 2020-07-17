# Continuous Delivery Principles

## Goals

By the end of the session you will:

- Identify and reduce risks in deployment processes.
- Manage work through a pipeline.
- Identify and mitigate “anti-patterns” in team processes.
- Understand the concepts of Agile and Lean.

## Agenda

- Case study "A company in trouble"
- Case study "A better way"
- Objectives
- Gains
- Agile methodologies
- Traps

## Case study 1: 10 mins

- Early morning "2am".
- Monthly roll-up of functionality.
- 1+ month lead time.
- Manual post-deployment regression testing.
- Back-out plan.

Because releases are painful and risky, the common tendancy is to roll more functionality into them, which further increases risk.

Stakeholder frustration. Release plans are generally fixed at least a month in advance, preventing short turn-around times for business critical changes.

## Case study 2: 10 mins

- Multiple releases in a day.
- Lead times measured in hours or minutes.
- Quick exploratory test.
- Hotfix instead of revert.

## Objective: 10 minutes

- Little and often
- Things needed to support LaO:

  - A way to deploy the software to a test or live environment at the push of a button.
  - Representative test environment.
  - Code always in a releasable state.
  - Autonomy within the team to approve features against the agreed acceptance criteria.
  - A process to automatically verify critical paths through the software work correctly once deployed.

## Gains: 10 mins

- Deployment at a moments notice
- Fail forward

  With small, frequent releases, it should be easier to determine the root cause of a failed release. It should then be possible to identify a fix which can then be quickly released through the same process.

- Reduce waste
- Confidence
- Mental health

  Cognitive load of managing and organising large releases can take its toll, especially at the early hours of the morning!

## Agile methodologies: 10 mins

- Agile

  There has been a lot of material written that covers Agile.

- Agile Manifesto

  - **Individuals and interactions** over processes and tools.
  - **Working software** over comprehensive documentation.
  - **Customer collaboration** over contract negotiation.
  - **Responding to change** over following a plan.

- Extreme Programming
- Lean

## Traps: 10 mins

- Perfect is the enemy of the good
- Gold plating
- Feature branching

  - Does not permit deployment at a moments notice.
  - Generally used for larger pieces of work that may be in progress for a large amount of timne.

- Single points of failure: technology or people
- Agile is not a project planning methodology
- Scrumfall, Fragile, Cargo culting
