// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Abstractions.Themes;

/// <summary>Represents a theme.</summary>
public interface IThemeInfo
{
    /// <summary>Gets or sets the ID of the theme.</summary>
    int ThemeId { get; set; }

    /// <summary>Gets or sets the ID of the theme package.</summary>
    int ThemePackageId { get; set; }

    /// <summary>Gets or sets the source of the theme.</summary>
    string ThemeSource { get; set; }
}
