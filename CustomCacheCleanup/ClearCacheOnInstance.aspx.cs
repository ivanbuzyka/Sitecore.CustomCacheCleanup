using Sitecore.Caching;
using Sitecore.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomCacheCleanup
{
  public partial class ClearCacheOnInstance : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      var instanceName = Request.QueryString["instanceName"];
      if(string.IsNullOrEmpty(instanceName))
      {
        StatusLiteral.Text = "'instanceName' query string is absent, please provide valid one";
        return;
      }

      // getting current machine name (which is also instance name for Azure Web App)
      string machineName = Environment.GetEnvironmentVariable("computername");
      if (machineName.Equals(instanceName, StringComparison.InvariantCultureIgnoreCase))
      {
        CacheStatistics statisticsBefore = CacheManager.GetStatistics();
        var cacheStatsBeforeCleanup = string.Format("Entries: {0}, Size: {1}", (object)statisticsBefore.TotalCount, (object)statisticsBefore.TotalSize);

        // desired instance matched. Proceed with cache cleanup
        foreach (ICacheInfo allCach in CacheManager.GetAllCaches())
        { 
          allCach.Clear();
        }

        TypeUtil.ClearSizeCache();

        CacheStatistics statisticsAfter = CacheManager.GetStatistics();
        var cacheStatsAfterCleanup = string.Format("Entries: {0}, Size: {1}", (object)statisticsAfter.TotalCount, (object)statisticsAfter.TotalSize);

        StatusLiteral.Text = string.Format("Instance: '{0}' matched <br/> Cache statistics before cleanup: <p>{1}</p> <br/> Cache statistics after cleanup: <p>{2}</p>", machineName, cacheStatsBeforeCleanup, cacheStatsAfterCleanup);
      }
      else
      {
        StatusLiteral.Text = string.Format("Instance: '{0}', hasn't matched. You were forwarded to the instance '{1}', please refresh the page...", instanceName, machineName);
      }
    }
  }
}