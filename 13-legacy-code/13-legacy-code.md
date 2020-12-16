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
- Libraries

## How to prevent or quickly identify rot

- Less-trodden paths.
- Abandoned but functioning.
- Automated lawn mowers:
    - Acceptance tests for key user journeys.
    - Scheduled automated builds.
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
