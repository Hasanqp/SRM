# PR Service – Business Documentation

## 📌 Overview
The Purchase Request (PR) service manages the lifecycle of purchase requests
from creation until approval or rejection.

## 🔄 Business Flow
1. Buyer creates a Purchase Request (Draft)
2. Buyer submits the PR
3. Approver reviews the PR
4. PR is either Approved or Rejected

## 🧠 Business Rules
- PR starts in Draft state
- Only Draft PRs can be submitted
- Only Submitted PRs can be approved or rejected
- Rejection requires a reason
- Approved PRs are immutable

## 📊 State Diagram
![PR State Diagram](diagrams/pr-state-diagram.puml)
