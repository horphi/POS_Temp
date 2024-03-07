using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cz.AspNetJarvisCore.Web.Authentication.JwtBearer
{
	public static class JwtTokenMiddleware
	{
		public static IApplicationBuilder UseJwtTokenMiddleware(this IApplicationBuilder app, string schema = "Bearer")
		{
			return app.Use(async delegate(HttpContext ctx, Func<Task> next)
			{
				IIdentity identity = ctx.User.Identity;
				if (identity == null || !identity.IsAuthenticated)
				{
					AuthenticateResult authenticateResult = await ctx.AuthenticateAsync(schema);
					if (authenticateResult.Succeeded && authenticateResult.Principal != null)
					{
						ctx.User = authenticateResult.Principal;
					}
				}
				await next();
			});
		}
	}
}
