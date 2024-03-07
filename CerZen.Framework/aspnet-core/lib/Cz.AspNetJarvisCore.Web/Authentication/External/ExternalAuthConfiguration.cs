﻿using System;
using System.Collections.Generic;
using Abp.Dependency;

namespace Cz.AspNetJarvisCore.Web.Authentication.External
{
	public class ExternalAuthConfiguration : IExternalAuthConfiguration, ISingletonDependency
	{
		[Obsolete("Use IExternalLoginInfoProviders")]
		public List<ExternalLoginProviderInfo> Providers { get; }

		public List<IExternalLoginInfoProvider> ExternalLoginInfoProviders { get; }

		public ExternalAuthConfiguration()
		{
			Providers = new List<ExternalLoginProviderInfo>();
			ExternalLoginInfoProviders = new List<IExternalLoginInfoProvider>();
		}
	}
}
