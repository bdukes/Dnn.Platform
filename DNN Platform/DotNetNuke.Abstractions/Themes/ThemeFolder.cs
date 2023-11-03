// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Abstractions.Themes;

/// <summary>The scope of a theme.</summary>
/// <remarks>This enum is used for <see cref="IThemeService.GetThemesInFolder"/>.</remarks>
public enum ThemeFolder
{
    /// <summary>All scopes are specified.</summary>
    All = 0,

    /// <summary>The theme can be used for all portals.</summary>
    /// <remarks>These themes are by default in the folder <c>Portals\_default\</c>.</remarks>
    Host = 1,

    /// <summary>The theme can only be used for the given portal.</summary>
    /// <remarks>These themes are by default in the folder <c>Portals\[PortalId]\</c> and <c>Portals\[PortalId]-System\</c>.</remarks>
    Portal = 2,
}
