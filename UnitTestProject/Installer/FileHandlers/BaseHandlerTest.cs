﻿namespace Nihei.SC4Buddy.Installer.FileHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using FluentAssertions;
    using Nihei.SC4Buddy.Model;
    using Nihei.SC4Buddy.Plugins.Installer.FileHandlers;
    using Xunit;

    public class BaseHandlerTest
    {
        private const string PathToTestMaterial = @"D:\users\asbjorn\SkyDrive\Code\Projects\SC4Buddy\TEST";

        #region set_FileInfo

        [Fact(DisplayName = "set_FileInfo, null as FileInfo, Throws ArgumentNullException")]
        public void FileInfoSetterTest1()
        {
            var instance = new BaseHandlerImpl();
            var exception = Assert.Throws<ArgumentNullException>(() => instance.FileInfo = null);
            exception.Message.Should().Contain("value");
        }

        [Fact(DisplayName = "set_FileInfo, FileInfo for non-existent file, Throws FileNotFoundException")]
        public void FileInfoSetterTest2()
        {
            var instance = new BaseHandlerImpl();
            var value = new FileInfo(Path.Combine(PathToTestMaterial, "nonexistentfile.test"));
            var exception = Assert.Throws<FileNotFoundException>(() => instance.FileInfo = value);
            exception.Message.Should().Be("FileInfo does not point to an existing file.");
        }

        #endregion

        #region Class implementation

        internal class PluginFileTestComparer : IEqualityComparer<PluginFile>
        {
            public bool Equals(PluginFile x, PluginFile y)
            {
                return x.Path.Equals(y.Path, StringComparison.OrdinalIgnoreCase)
                       && x.Checksum.Equals(y.Checksum, StringComparison.Ordinal);
            }

            public int GetHashCode(PluginFile obj)
            {
                return obj.Checksum.GetHashCode();
            }
        }

        private class BaseHandlerImpl : BaseHandler
        {
            public override string RequiredExtension
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public override IEnumerable<FileSystemInfo> ExtractFilesToTemp()
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
