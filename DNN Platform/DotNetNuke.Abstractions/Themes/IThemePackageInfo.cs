// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Abstractions.Themes;

using DotNetNuke.Abstractions.Collections;

/// <summary>The theme package info.</summary>
public interface IThemePackageInfo
{
    /// <summary>Gets or sets the ID of the package.</summary>
    int PackageId { get; set; }

    /// <summary>Gets or sets the ID of the theme package.</summary>
    int ThemePackageId { get; set; }

    /// <summary>Gets or sets the ID of the portal.</summary>
    /// <remarks>If the portal ID is <c>-1</c>, then the theme package is a global theme package.</remarks>
    int PortalId { get; set; }

    /// <summary>Gets or sets the name of the theme.</summary>
    string ThemeName { get; set; }

    /// <summary>Gets the themes in the theme package.</summary>
    IObjectList<IThemeInfo> Themes { get; }

    /// <summary>Gets or sets the type of the theme.</summary>
    ThemePackageType ThemeType { get; set; }
}
