# Task Tracker CLI Project

This is a simple command-line interface (CLI) task tracker application built using C#. It allows users to manage tasks through various commands, such as adding, updating, deleting, and listing tasks, as well as marking tasks as completed or in progress.

## Features

- **Add a task**: Add new tasks with a description.
- **Update a task**: Modify the description of existing tasks.
- **Delete a task**: Remove tasks by their ID.
- **Mark task as In Progress**: Change the status of a task to "In Progress".
- **Mark task as Completed**: Change the status of a task to "Done".
- **List tasks**: View all tasks or filter by status (e.g., "To Do", "In Progress", "Done").
- **Persistence**: Save and load tasks to and from a `tasks.json` file.

## Commands

The following commands are available for use in the CLI:

- `add <description>` - Add a new task with the given description.
- `update <id> <description>` - Update the task with the specified ID and new description.
- `delete <id>` - Delete the task with the specified ID.
- `inprogress <id>` - Mark the task with the specified ID as "In Progress".
- `complete <id>` - Mark the task with the specified ID as "Done".
- `list` - List all tasks.
- `list <status>` - List tasks filtered by the status (e.g., `list done`).
- `help` - Display available commands.

## Project URL

You can view the project on Roadmap at the following URL: [Roadmap - Task Tracker](https://roadmap.sh/projects/task-tracker)
