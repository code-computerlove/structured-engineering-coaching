# All Code is Legacy Code

## Goals

- How to reduce "bit rot".
- How to organise a project for newcomers.
- Recognise the uses of Architectural Decisions Records.
- How to use automated tasks and services to quickly identify issues.

# Bit Rot

## What rots?

- Certificate expiry
- Disk space
- User credentials instead of system accounts
- Third party APIs
- Libraries. Deprecation. Vendor death (leftpad).
- System updates (Andy's crypto story)

## How to prevent or quickly identify rot

- Less-trodden paths.
  - Monthly reports, rarely used features.
  - Worst-case: data loss.
- 'Abandoned' but functioning.
  - Important daily scheduled tasks
  - Message handlers
  - Too important to touch. Desktop machine with warning post-it 'DO NOT TURN OFF!'
- Automated lawn mowers:
    - Acceptance tests for key user journeys. Probably less than 5. Not annoying!
    - Scheduled automated builds. Azure DevOps. Travis. CircleCI. Teamcity. Octopus Deploy.
- Regular maintenance. Updating frameworks/ dependencies to supported versions.

## Build for legacy

- Automated monitoring for:
    - Cert expiry.
    - Disk space growth rate.
    - Credential expiry.

- Don't ignore library deprecation warnings.
- Subscribe to project updates on npm/github.

# SaaS

- Dependabot
- Snyk
- App Insights Smart Detection

# Organising a project for newcomers

- README.
- Single click build
- Single click deployment

## Architecture Decision Records

- Use for any architecture decision.
- What? Why? How?
