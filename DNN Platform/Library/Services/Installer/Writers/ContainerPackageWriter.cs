﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.Services.Installer.Writers
{
    using System.Xml;

    using DotNetNuke.Services.Installer.Packages;
    using DotNetNuke.UI.Skins;

    /// <summary>The ContainerPackageWriter class.</summary>
    public class ContainerPackageWriter : SkinPackageWriter
    {
        /// <summary>Initializes a new instance of the <see cref="ContainerPackageWriter"/> class.</summary>
        /// <param name="package"></param>
        public ContainerPackageWriter(PackageInfo package)
            : base(package)
        {
            this.BasePath = "Portals\\_default\\Containers\\" + this.SkinPackage.ThemeName;
        }

        /// <summary>Initializes a new instance of the <see cref="ContainerPackageWriter"/> class.</summary>
        /// <param name="themePackage"></param>
        /// <param name="package"></param>
        public ContainerPackageWriter(SkinPackageInfo themePackage, PackageInfo package)
            : base(themePackage, package)
        {
            this.BasePath = "Portals\\_default\\Containers\\" + themePackage.ThemeName;
        }

        /// <inheritdoc/>
        protected override void WriteFilesToManifest(XmlWriter writer)
        {
            var containerFileWriter = new ContainerComponentWriter(this.SkinPackage.ThemeName, this.BasePath, this.Files, this.Package);
            containerFileWriter.WriteManifest(writer);
        }
    }
}
