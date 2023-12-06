# DemoSeleniumSpecFlow

# Code Repository Usage Guide

## Prerequisites
1. Follow the [install guide for SpecFlow](https://docs.specflow.org/projects/specflow/en/latest/visualstudio/visual-studio-installation.html) for Visual Studio.

## Getting Started

### Step 1: Open Solution in Visual Studio
- Launch Visual Studio.
- Open the solution file in Visual Studio.

### Step 2: Build the Solution
- In Visual Studio, navigate to the menu and select **Build > Build Solution**.
- Ensure that the solution builds without any errors.

### Step 3: Run All Tests
- In Visual Studio, navigate to the menu and select **Test > Run All Tests**.
- Monitor the Test Explorer for the execution status.

## Frequently Asked Questions (FAQ)

### Q: No Tests Visible
- **A1:** If the Test Explorer is not visible, go to **Test > Test Explorer** to make it visible.
- **A2:** Ensure that everything is built without errors. Resolve any build errors before running tests.

### Q: Error - "System.InvalidOperationException: session not created: This version of ChromeDriver only supports Chrome version xxx"
- **A:** Make sure the current version of Chrome matches the one specified for ChromeDriver (currently 119.0.6045.10500).

## Additional Notes
- Please refer to the SpecFlow documentation for any additional configuration or feature-specific information.
