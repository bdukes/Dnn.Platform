// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Abstractions.Themes;

using System.Collections.Generic;

using DotNetNuke.Abstractions.Portals;

/// <summary>Handles the Business Control Layer for Themes.</summary>
public interface IThemeService
{
    /// <summary>Gets the folder name for the specified <paramref name="packageType"/>.</summary>
    /// <param name="packageType">The type of the theme package.</param>
    /// <returns>The folder name.</returns>
    string GetFolderName(ThemePackageType packageType);

    /// <summary>Gets the global default theme source.</summary>
    /// <param name="packageType">The type of the theme package.</param>
    /// <param name="themeType">The type of the theme.</param>
    /// <returns>The global default edit theme.</returns>
    string GetDefaultThemeSource(ThemePackageType packageType, ThemeType themeType);

    /// <summary>Gets a theme package by its ID.</summary>
    /// <param name="packageId">The theme package ID.</param>
    /// <returns>The theme package.</returns>
    IThemePackageInfo GetThemePackageById(int packageId);

    /// <summary>Gets a theme package by its ID.</summary>
    /// <param name="portalId">The portal ID.</param>
    /// <param name="themeName">The name of the theme.</param>
    /// <param name="packageType">The type of the theme package.</param>
    /// <returns>The theme package.</returns>
    IThemePackageInfo GetThemePackage(int portalId, string themeName, ThemePackageType packageType);

    /// <summary>Creates a new instance of <see cref="IThemeInfo"/>.</summary>
    /// <returns>The theme.</returns>
    IThemeInfo CreateTheme();

    /// <summary>Creates a new instance of <see cref="IThemePackageInfo"/>.</summary>
    /// <returns>The theme package.</returns>
    IThemePackageInfo CreateThemePackage();

    /// <summary>Adds a new theme.</summary>
    /// <param name="theme">The theme to add.</param>
    /// <returns>The theme ID.</returns>
    int AddTheme(IThemeInfo theme);

    /// <summary>Adds a theme package.</summary>
    /// <param name="themePackage">The theme package to add.</param>
    /// <returns>The theme package ID.</returns>
    int AddThemePackage(IThemePackageInfo themePackage);

    /// <summary>Checks if a theme can be deleted.</summary>
    /// <param name="folderPath">Path to the theme folder.</param>
    /// <param name="portalHomeDirMapPath">Path to the portal home directory (<see cref="IPortalSettings.HomeDirectoryMapPath"/>).</param>
    /// <returns><see langword="true"/> if the theme can be deleted.</returns>
    bool CanDeleteThemeFolder(string folderPath, string portalHomeDirMapPath);

    /// <summary>Deletes a theme.</summary>
    /// <param name="theme">The theme to delete.</param>
    void DeleteTheme(IThemeInfo theme);

    /// <summary>Deletes a theme package.</summary>
    /// <param name="themePackage">The theme package to delete.</param>
    void DeleteThemePackage(IThemePackageInfo themePackage);

    /// <summary>Gets the theme source path.</summary>
    /// <example>
    /// <c>[G]Skins/Xcillion/Inner.ascx</c> becomes <c>[G]Skins/Xcillion</c>.
    /// </example>
    /// <param name="themeSource">The input theme source path.</param>
    /// <returns>The theme source path.</returns>
    string FormatThemePath(string themeSource);

    /// <summary>Formats the theme source path.</summary>
    /// <remarks>
    /// By default the following tokens are replaced:<br />
    /// <c>[G]</c> - Host path (default: '/Portals/_default/').<br />
    /// <c>[S]</c> - Home system directory (default: '/Portals/[PortalID]-System/').<br />
    /// <c>[L]</c> - Home directory (default: '/Portals/[PortalID]/').
    /// </remarks>
    /// <example>
    /// <c>[G]Skins/Xcillion/Inner.ascx</c> becomes <c>/Portals/_default/Skins/Xcillion/Inner.ascx</c>.
    /// </example>
    /// <param name="themeSource">The input theme source path.</param>
    /// <param name="portalSettings">The portal settings containing configuration data.</param>
    /// <returns>The formatted theme source path.</returns>
    string FormatThemeSource(string themeSource, IPortalSettings portalSettings);

    /// <summary>Determines if a given theme is defined as a global theme.</summary>
    /// <param name="themeSource">This is the app relative path and filename of the theme to be checked.</param>
    /// <returns><see langword="true"/> if the theme is located in the HostPath child directories.</returns>
    /// <remarks>This function performs a quick check to detect the type of theme that is
    /// passed as a parameter.  Using this method abstracts knowledge of the actual location
    /// of themes in the file system.
    /// </remarks>
    bool IsGlobalTheme(string themeSource);

    /// <summary>Sets the theme for the specified <paramref name="portalId"/> and <paramref name="themeType"/>.</summary>
    /// <param name="packageType">The type of the theme package.</param>
    /// <param name="portalId">The portal to set the theme for or <c>-1</c> for the global theme.</param>
    /// <param name="themeType">The type of the theme.</param>
    /// <param name="themeSource">The theme source path.</param>
    void SetTheme(ThemePackageType packageType, int portalId, ThemeType themeType, string themeSource);

    /// <summary>Updates an existing theme.</summary>
    /// <param name="theme">The theme to update.</param>
    void UpdateTheme(IThemeInfo theme);

    /// <summary>Updates an existing theme package.</summary>
    /// <param name="themePackage">The theme package to update.</param>
    void UpdateThemePackage(IThemePackageInfo themePackage);

    /// <summary>Get all themes for the specified <paramref name="portalInfo"/> within the specified <paramref name="folder"/>.</summary>
    /// <param name="portalInfo">The portal to get the themes for.</param>
    /// <param name="themeRoot">The theme type to search for themes. Default: <see cref="ThemePackageType.Theme"/>.</param>
    /// <param name="folder">The scope to search for themes. Default: <see cref="ThemeFolder.All"/>.</param>
    /// <returns>A list of themes.</returns>
    IEnumerable<KeyValuePair<string, string>> GetThemesInFolder(IPortalInfo portalInfo, ThemeType themeRoot = ThemeType.Site, ThemeFolder folder = ThemeFolder.All);
}
