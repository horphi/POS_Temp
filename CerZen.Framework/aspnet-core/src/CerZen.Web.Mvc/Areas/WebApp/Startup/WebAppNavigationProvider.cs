using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using CerZen.Authorization;

namespace CerZen.Web.Areas.WebApp.Startup
{
    public class WebAppNavigationProvider : NavigationProvider
    {
        public const string MenuName = "App";

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            menu
                .AddItem(new MenuItemDefinition(
                    WebAppPageNames.Common.UsopPots, 
                    L("UsopPots"), 
                    url: "WebApp/UsopPots", 
                    icon: "flaticon-more", 
                    permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_UsopPots)
                    )
                )   
                .AddItem(new MenuItemDefinition(
                        WebAppPageNames.Host.Dashboard,
                        L("Dashboard"),
                        url: "WebApp/HostDashboard",
                        icon: "flaticon-line-graph",
                        permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Administration_Host_Dashboard)
                    )
                ).AddItem(new MenuItemDefinition(
                        WebAppPageNames.Host.Tenants,
                        L("Tenants"),
                        url: "WebApp/Tenants",
                        icon: "flaticon-list-3",
                        permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Tenants)
                    )
                ).AddItem(new MenuItemDefinition(
                        WebAppPageNames.Host.Editions,
                        L("Editions"),
                        url: "WebApp/Editions",
                        icon: "flaticon-app",
                        permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Editions)
                    )
                ).AddItem(new MenuItemDefinition(
                        WebAppPageNames.Tenant.Dashboard,
                        L("Dashboard"),
                        url: "WebApp/TenantDashboard",
                        icon: "flaticon-line-graph",
                        permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Tenant_Dashboard)
                    )
                ).AddItem(new MenuItemDefinition(
                        WebAppPageNames.Common.Administration,
                        L("Administration"),
                        icon: "flaticon-interface-8"
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.OrganizationUnits,
                            L("OrganizationUnits"),
                            url: "WebApp/OrganizationUnits",
                            icon: "flaticon-map",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_OrganizationUnits)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.Roles,
                            L("Roles"),
                            url: "WebApp/Roles",
                            icon: "flaticon-suitcase",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Roles)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.Users,
                            L("Users"),
                            url: "WebApp/Users",
                            icon: "flaticon-users",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Users)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.Languages,
                            L("Languages"),
                            url: "WebApp/Languages",
                            icon: "flaticon-tabs",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Languages)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.AuditLogs,
                            L("AuditLogs"),
                            url: "WebApp/AuditLogs",
                            icon: "flaticon-folder-1",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_AuditLogs)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Host.Maintenance,
                            L("Maintenance"),
                            url: "WebApp/Maintenance",
                            icon: "flaticon-lock",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Host_Maintenance)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Tenant.SubscriptionManagement,
                            L("Subscription"),
                            url: "WebApp/SubscriptionManagement",
                            icon: "flaticon-refresh",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Tenant_SubscriptionManagement)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.UiCustomization,
                            L("VisualSettings"),
                            url: "WebApp/UiCustomization",
                            icon: "flaticon-medical",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_UiCustomization)
                        )
                    ).AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.WebhookSubscriptions,
                            L("WebhookSubscriptions"),
                            url: "WebApp/WebhookSubscription",
                            icon: "flaticon2-world",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_WebhookSubscription)
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.DynamicProperties,
                            L("DynamicProperties"),
                            url: "WebApp/DynamicProperty",
                            icon: "flaticon-interface-8",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_DynamicProperties)
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                            WebAppPageNames.Host.Settings,
                            L("Settings"),
                            url: "WebApp/HostSettings",
                            icon: "flaticon-settings",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Host_Settings)
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                            WebAppPageNames.Tenant.Settings,
                            L("Settings"),
                            url: "WebApp/Settings",
                            icon: "flaticon-settings",
                            permissionDependency: new SimplePermissionDependency(AppPermissions
                                .Pages_Administration_Tenant_Settings)
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                            WebAppPageNames.Common.Notifications,
                            L("Notifications"),
                            icon: "flaticon-alarm"
                        ).AddItem(new MenuItemDefinition(
                                WebAppPageNames.Common.Notifications_Inbox,
                                L("Inbox"),
                                url: "WebApp/Notifications",
                                icon: "flaticon-mail-1"
                            )
                        )
                        .AddItem(new MenuItemDefinition(
                                WebAppPageNames.Common.Notifications_MassNotifications,
                                L("MassNotifications"),
                                url: "WebApp/Notifications/MassNotifications",
                                icon: "flaticon-paper-plane",
                                permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Administration_MassNotification)
                            )
                        )
                    )
                ).AddItem(new MenuItemDefinition(
                        WebAppPageNames.Common.DemoUiComponents,
                        L("DemoUiComponents"),
                        url: "WebApp/DemoUiComponents",
                        icon: "flaticon-shapes",
                        permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_DemoUiComponents)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CerZenConsts.LocalizationSourceName);
        }
    }
}
