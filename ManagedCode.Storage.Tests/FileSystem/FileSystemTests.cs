﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ManagedCode.Storage.Core;
using ManagedCode.Storage.FileSystem;
using ManagedCode.Storage.FileSystem.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ManagedCode.Storage.Tests.FileSystem;

public class FileSystemTests : StorageBaseTests
{
    public FileSystemTests()
    {
        var services = new ServiceCollection();

        var testDirectory = Path.Combine(Environment.CurrentDirectory, "managed-code-bucket");

        services.AddFileSystemStorage(opt =>
        {
            opt.CommonPath = testDirectory;
            opt.Path = "managed-code-bucket";
        });

        var provider = services.BuildServiceProvider();

        Storage = provider.GetService<IFileSystemStorage>();
    }
}