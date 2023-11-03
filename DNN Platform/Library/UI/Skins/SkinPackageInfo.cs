// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.UI.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Xml.Serialization;

    using DotNetNuke.Abstractions.Collections;
    using DotNetNuke.Abstractions.Themes;
    using DotNetNuke.Collections;
    using DotNetNuke.Common.Utilities;
    using DotNetNuke.Entities;
    using DotNetNuke.Entities.Modules;
    using Newtonsoft.Json;

    /// Project  : DotNetNuke
    /// Class    : SkinPackageInfo
    ///
    /// <summary>    Handles the Business Object for Skins.</summary>
    [Serializable]
    public class SkinPackageInfo : BaseEntityInfo, IHydratable, IThemePackageInfo
    {
        private int packageId = Null.NullInteger;
        private int portalId = Null.NullInteger;
        private string skinName;
        private int skinPackageId = Null.NullInteger;
        private string skinType;
        private Dictionary<int, string> skins = new Dictionary<int, string>();
        private List<SkinInfo> themes = new List<SkinInfo>();
        private AbstractionList<IThemeInfo, SkinInfo> abstractSkins;

        /// <inheritdoc cref="IThemePackageInfo.PackageId"/>
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.PackageId)} instead. Scheduled for removal in v11.0.0.")]
        public int PackageID
        {
            get
            {
                return ((IThemePackageInfo)this).PackageId;
            }

            set
            {
                ((IThemePackageInfo)this).PackageId = value;
            }
        }

        /// <inheritdoc cref="IThemePackageInfo.ThemePackageId" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.ThemePackageId)} instead. Scheduled for removal in v11.0.0.")]
        public int SkinPackageID
        {
            get
            {
                return ((IThemePackageInfo)this).ThemePackageId;
            }

            set
            {
                ((IThemePackageInfo)this).ThemePackageId = value;
            }
        }

        /// <inheritdoc cref="IThemePackageInfo.PortalId"/>
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.PortalId)} instead. Scheduled for removal in v11.0.0.")]
        public int PortalID
        {
            get
            {
                return ((IThemePackageInfo)this).PortalId;
            }

            set
            {
                ((IThemePackageInfo)this).PortalId = value;
            }
        }

        /// <inheritdoc cref="IThemePackageInfo.ThemeName" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.ThemeName)} instead. Scheduled for removal in v11.0.0.")]
        public string SkinName
        {
            get => this.ThemeName;
            set => this.ThemeName = value;
        }

        /// <inheritdoc/>
        public string ThemeName
        {
            get => this.skinName;
            set => this.skinName = value;
        }

        /// <summary>Gets or sets a dictionary mapping from <see cref="SkinInfo.ThemeId"/> to <see cref="SkinInfo.ThemeSource"/>.</summary>
        [XmlIgnore]
        [JsonIgnore]
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.Themes)} instead. Scheduled for removal in v11.0.0.")]
        public Dictionary<int, string> Skins
        {
            get
            {
                return this.skins;
            }

            set
            {
                this.skins = value;
            }
        }

        /// <inheritdoc cref="IThemePackageInfo.Themes" />
        [XmlIgnore]
        [JsonIgnore]
        public List<SkinInfo> Themes
        {
            get
            {
                return this.themes;
            }

            set
            {
                this.themes = value;
            }
        }

        /// <inheritdoc cref="IThemePackageInfo.ThemeType" />
        [Obsolete($"Deprecated in DotNetNuke 9.13.1. Use {nameof(IThemePackageInfo)}.{nameof(IThemePackageInfo.ThemeType)} instead. Scheduled for removal in v11.0.0.")]
        public string SkinType
        {
            get
            {
                return this.skinType;
            }

            set
            {
                this.skinType = value;
            }
        }

        /// <inheritdoc/>
        public int KeyID
        {
            get
            {
                return ((IThemePackageInfo)this).ThemePackageId;
            }

            set
            {
                ((IThemePackageInfo)this).ThemePackageId = value;
            }
        }

        /// <inheritdoc/>
        [XmlIgnore]
        [JsonIgnore]
        int IThemePackageInfo.PackageId
        {
            get => this.packageId;
            set => this.packageId = value;
        }

        /// <inheritdoc/>
        [XmlIgnore]
        [JsonIgnore]
        int IThemePackageInfo.ThemePackageId
        {
            get => this.skinPackageId;
            set => this.skinPackageId = value;
        }

        /// <inheritdoc/>
        [XmlIgnore]
        [JsonIgnore]
        IObjectList<IThemeInfo> IThemePackageInfo.Themes
        {
            get
            {
                return this.abstractSkins ??= new AbstractionList<IThemeInfo, SkinInfo>(this.Themes);
            }
        }

        /// <inheritdoc/>
        [XmlIgnore]
        [JsonIgnore]
        ThemePackageType IThemePackageInfo.ThemeType
        {
            get => SkinUtils.FromDatabaseName(this.SkinType);
            set => this.SkinType = SkinUtils.ToDatabaseName(value);
        }

        /// <inheritdoc/>
        [XmlIgnore]
        [JsonIgnore]
        int IThemePackageInfo.PortalId
        {
            get => this.portalId;
            set => this.portalId = value;
        }

        /// <inheritdoc/>
        public void Fill(IDataReader dr)
        {
            var @this = (IThemePackageInfo)this;
            @this.ThemePackageId = Null.SetNullInteger(dr["SkinPackageID"]);
            @this.PackageId = Null.SetNullInteger(dr["PackageID"]);
            @this.ThemeName = Null.SetNullString(dr["SkinName"]);
            this.SkinType = Null.SetNullString(dr["SkinType"]);

            // Call the base classes fill method to populate base class properties
            this.FillInternal(dr);

            if (dr.NextResult())
            {
                while (dr.Read())
                {
                    int skinId = Null.SetNullInteger(dr["SkinID"]);
                    if (skinId > Null.NullInteger)
                    {
                        var skinSrc = Null.SetNullString(dr["SkinSrc"]);
                        this.skins[skinId] = skinSrc;
                        this.themes.Add(new SkinInfo
                        {
                            ThemeId = skinId,
                            ThemeSource = skinSrc,
                            ThemePackageId = @this.ThemePackageId,
                            PortalId = @this.PortalId,
                            SkinRoot = SkinUtils.FromDatabaseName(this.SkinType) switch
                            {
                                ThemePackageType.Container => SkinController.RootContainer,
                                ThemePackageType.Theme => SkinController.RootSkin,
                                _ => throw new ArgumentOutOfRangeException(nameof(this.SkinType), this.SkinType, "Invalid skin type."),
                            },
                        });
                    }
                }
            }
        }
    }
}
