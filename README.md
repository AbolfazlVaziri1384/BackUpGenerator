# Backup Generator

A Windows application for creating automated backups of files and folders with RAR compression.

## Features

- Create password-protected RAR archives
- Automatic scheduled backups
- Clean project folders (bin, obj, .vs) before backup
- Support for both Persian and English timestamp formats
- Save and load backup configurations
- Simple and intuitive user interface

## Requirements

- Windows 7 or later
- .NET Framework 4.5 or later
- WinRAR installed on the system (for RAR compression)

## Installation

1. Download the latest release from the [Releases page](#)
2. Run the setup executable
3. Follow the installation wizard

## Usage

1. Select files and folders to backup
2. Choose destination path
3. Set backup options:
   - File name
   - Password protection
   - Timestamp format
   - Automatic backup interval
   - Cleanup options
4. Click "Generate" to create backup
5. Save configuration for future use if needed

## Configuration Saving

The application automatically saves your backup configurations in `LastSave.ini` file in the application directory. You can:

- Save current settings
- Load previously saved configurations
- Delete saved configurations

## Building from Source

1. Clone this repository
2. Open the solution in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)
