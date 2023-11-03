// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.UI.Skins
{
    using System;

    using DotNetNuke.Abstractions.Themes;

    /// Project  : DotNetNuke
    /// Class    : SkinInfo
    ///
    /// <summary>    Handles the Business Object for Skins.</summary>
    [Serializable]
    public class SkinInfo : IThemeInfo
    {
        private int portalId;
        private int skinId;
        private int skinPackageId;
        private string skinRoot;
        private string skinSrc;
        private SkinType skinType;

        /// <inheritdoc cref="IThemeInfo.ThemeId" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemeInfo)}.{nameof(IThemeInfo.ThemeId)} instead. Scheduled for removal in v11.0.0.")]
        public int SkinId
        {
            get => this.ThemeId;
            set => this.ThemeId = value;
        }

        /// <inheritdoc />
        public int ThemeId
        {
            get => this.skinId;
            set => this.skinId = value;
        }

        /// <inheritdoc cref="IThemeInfo.ThemePackageId" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemeInfo)}.{nameof(IThemeInfo.ThemePackageId)} instead. Scheduled for removal in v11.0.0.")]
        public int SkinPackageId
        {
            get => this.ThemePackageId;
            set => this.ThemePackageId = value;
        }

        /// <inheritdoc />
        public int ThemePackageId
        {
            get => this.skinPackageId;
            set => this.skinPackageId = value;
        }

        public int PortalId
        {
            get => this.portalId;
            set => this.portalId = value;
        }

        public string SkinRoot
        {
            get => this.skinRoot;
            set => this.skinRoot = value;
        }

        [Obsolete("Deprecated in DotNetNuke 10.0.0. No replacement. Scheduled removal in v12.0.0.")]
        public SkinType SkinType
        {
            get => this.skinType;
            set => this.skinType = value;
        }

        /// <inheritdoc cref="IThemeInfo.ThemeSource" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemeInfo)}.{nameof(IThemeInfo.ThemeSource)} instead. Scheduled for removal in v11.0.0.")]
        public string SkinSrc
        {
            get => this.ThemeSource;
            set => this.ThemeSource = value;
        }

        /// <inheritdoc />
        public string ThemeSource
        {
            get => this.skinSrc;
            set => this.skinSrc = value;
        }
    }
}
