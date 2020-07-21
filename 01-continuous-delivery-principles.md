# Continuous Delivery Principles

## Goals

By the end of the session you will:

- Identify and reduce risks in deployment processes.
- Manage work through a pipeline.
- Identify and mitigate “anti-patterns” in team processes.
- Understand the concepts of Agile and Lean.

## Content

- Case study "A company in trouble"
- Case study "A better way"
- Objectives
- Gains
- Agile methodologies
- Traps

## Case study 1: 10 mins

- Early morning "2am".
- Monthly roll-up of functionality across all products in 1 super solution.
- 1+ month lead time.
- Code was compiled on release managers machine and manually copied to 2 dozen servers.
- Manual post-deployment regression testing.
- A comprehensive back-out plan had to be decided in advance.
- Releases routinely took 10+ hours plus another 8 hours if rolled back.

Releases were difficult, time consuming and the site would be unavailable whilst being released. It therefore logically seemed to follow that releases should be performed out of hours and be as infrequent as possible.

However, as releases increase in size and scope, problems with them increase exponentially.

| # of tickets | Possible sources of bugs (discrete functionality and unforeseen interactions) |
| ------------ | ----------------------------------------------------------------------------- |
| 1            | 1! = 1                                                                        |
| 2            | 2! = 2 x 1 = 2                                                                |
| 3            | 3! = 3 x 2 x 1 = 6                                                            |
| 4            | 4! = 4 x 3 x 2 x 1 = 24                                                       |

Stakeholder frustration. Release plans are generally fixed at least a month in advance, preventing short turn-around times for business critical changes. IT viewed negatively.

IT disillusionment. Releases dreaded. Weeks spent investigating release issues.

## Case study 2: 10 mins

- Products split into own solutions.
- Automated deployment of each product.
- Multiple releases in a day.
- Lead times measured in hours or minutes.
- Quick exploratory test.
- Hotfix instead of revert.

Releases usually contained a single item. If a release failed the cause was usually easy to identify and hotfix.

It was demonstrated to the company that a simple feature request could be delivered the same day it was raised.

Each employee got to perform a release of the main site to break the perception of releases being dangerous.

In some cases, departments now struggled to find enough work for teams!

## Objective: 10 minutes

- Little and often
- Things needed to support LaO:

  - A way to deploy the software to a test or live environment at the push of a button.
  - Representative test environment.
  - Code always in a releasable state.
  - Autonomy within the team to approve features against the agreed acceptance criteria.
  - A process to automatically verify critical paths through the software work correctly once deployed.

The manual release process was error prone. Lots of knowledge existed only in the release manager's head. Effectively there was a [Bus Factor](https://en.wikipedia.org/wiki/Bus_factor) of 1!

Differences in environments include: different versions of database software, different framework versions, differences in which Windows updates have been applied. One of the more difficult bugs to diagnose I've seen involved people being randomly logged out of a site. Eventually it was traced to one out of dozen servers that served the site missing a Windows cryptography update. This one server rejected session cookies created on others so when a user hit the one server through the load balancer they'd be logged out.

People always focus on how we can speed up devs but the devs are often not the problem. When we had a client frustrated with our delivery speed we carefully monitored how work moved through the board for a month and the results were interesting. In dev accounted for less than 10% of the tickets' life time. The vast majority of time was spent waiting for client acceptance approval.

## Gains: 10 mins

- Deployment at a moments notice
- Fail forward
- Reduce waste
- Confidence
- Mental health

Repeated releases are less error prone – cumulative errors can be fixed when they occur (package deprecation, tooling version changes, etc.) as opposed to all at the same time – also whilst compiling a multitude of features into a staging environment. Transient faults will also be identified purely because the builds are being run more often, and can be made more robust.

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
