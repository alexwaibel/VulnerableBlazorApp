# Vulnerable Blazor App

## About
This is an intentionally vulnerable webapp written using [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor), Microsoft's latest .NET web framework. It is intended to provide code examples to go alongside the concepts in [PortSwigger Web Academy](https://portswigger.net/web-security/dashboard). See [the wiki](https://github.com/alexwaibel/VulnerableBlazorApp/wiki) for a write-up.

WARNING: This web app is intentionally riddled with vulnerabilities. DO NOT upload it to a host facing the public internet. For best results, run this in a virtual machine

## Getting Started
To run the application, follow the below instructions.

### Prerequisites
- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/en-us/download) installed

### Running Application
- Clone this repo and cd into the root directory
    ```bash
    cd VulnerableBlazorApp
    ```
- Run the database migrations
    ```bash
    dotnet ef database update
    ```
- Start the application
    ```bash
    dotnet watch
    ```
- In the terminal output, look for the line `Now listening on: http://localhost:{port}` where the `{port}` will be a randomly selected port
- Navigate to the above address in your browser of choice