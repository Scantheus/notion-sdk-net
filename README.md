<div align="center">
	<h1>Notion SDK for .Net</h1>
	<p>
		<b>A simple and easy to use client for the <a href="https://developers.notion.com">Notion API</a></b>
	</p>
	<br>
</div>

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/notion-dotnet/notion-sdk-net)
![GitHub](https://img.shields.io/github/license/notion-dotnet/notion-sdk-net)

[![Build Status](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/ci-build.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/ci-build.yml)
[![Build artifacts](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/build-artifacts-code.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/build-artifacts-code.yml)
[![Publish Code](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/publish-code.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/publish-code.yml)
[![CodeQL](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/notion-dotnet/notion-sdk-net/actions/workflows/codeql-analysis.yml)

![LGTM Alerts](https://img.shields.io/lgtm/alerts/github/notion-dotnet/notion-sdk-net)
![LGTM Grade](https://img.shields.io/lgtm/grade/csharp/github/notion-dotnet/notion-sdk-net)

![GitHub last commit](https://img.shields.io/github/last-commit/notion-dotnet/notion-sdk-net)
![GitHub commit activity](https://img.shields.io/github/commit-activity/w/notion-dotnet/notion-sdk-net)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/notion-dotnet/notion-sdk-net)
![GitHub commit activity](https://img.shields.io/github/commit-activity/y/notion-dotnet/notion-sdk-net)

![GitHub repo size](https://img.shields.io/github/repo-size/notion-dotnet/notion-sdk-net)
![Lines of code](https://img.shields.io/tokei/lines/github/notion-dotnet/notion-sdk-net)

Provides the following packages:

| Package | Downloads | Nuget |
|---|---|---|
| Notion.Net | ![Nuget](https://img.shields.io/nuget/dt/Notion.Net?color=success) | ![Nuget](https://img.shields.io/nuget/v/Notion.Net) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Notion.Net) |



## Installation

.Net CLI

```
dotnet add package Notion.Net
```

## Usage

> Before getting started, you need to [create an integration](https://www.notion.com/my-integrations) and find the token. You can learn more about authorization [here](https://developers.notion.com/docs/authorization).

Import and initialize the client using the integration token created above.

```csharp
var client = new NotionClient(new ClientOptions
{
    AuthToken = "<Token>"
});
```

Make A request to any Endpoint. For example you can call below to fetch the paginated list of users.

```csharp
var usersList = await client.Users.ListAsync();
```

### Querying a database

After you initialized your client and got an id of a database, you can query it for any contained pages. You can add filters and sorts to your request. Here is a simple example:

```C#
// Date filter for page property called "When"
var dateFilter = new DateFilter("When", onOrAfter: DateTime.Now);

var queryParams = new DatabasesQueryParameters { Filter = dateFilter };
var pages = await client.Databases.QueryAsync(databaseId, queryParams);
```

Filters constructors contain all possible filter conditions, but you need to choose only condition per filter, all other should be `null`. So, for example this code would not filter by 2 conditions as one might expect:

```C#
var filter = new TextFilter("Name", startsWith: "Mr", contains: "John"); // WRONG FILTER USAGE

```

To use complex filters, use class `CompoundFilter`. It allows adding many filters and even nesting compound filters into each other (it works as filter group in Notion interface). Here is an example of filter that would return pages that were due in past month AND either had a certain assignee OR had high urgency:

```C#
var selectFilter = new SelectFilter("Urgency", equal: "High");
var assigneeFilter = new PeopleFilter("Assignee", contains: "some-uuid");
var dateFilter = new DateFilter("Due", pastMonth: new Dictionary<string, object>());

var orGroup = new List<Filter> { assigneeFilter, selectFilter };
var complexFiler = new CompoundFilter(
    and: new List<Filter> { dateFilter, new CompoundFilter(or: orGroup) }
);
```

## Supported Endpoints
- [ ] Databases
  - [x] Retrieve a database
  - [x] Query a database
  - [x] List databases
  - [ ] Create a Database
- [x] Pages
  - [x] Retrieve a page
  - [x] Create a page
  - [x] Update page
- [x] Blocks
  - [x] Retrieve Block Children
  - [x] Append Block Children
- [x] Users
  - [x] Retrieve a User
  - [x] List all users
- [x] Search

## Contribution Guideline

Hello! Thank you for choosing to help contribute to this open source library. There are many ways you can contribute and help is always welcome. You can read the detailed [Contribution Guideline](https://github.com/notion-dotnet/notion-sdk-net/blob/main/CONTRIBUTING.md) defined here - we will continue to improve it.

