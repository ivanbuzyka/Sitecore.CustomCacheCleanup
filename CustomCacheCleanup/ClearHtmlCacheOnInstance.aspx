<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearHtmlCacheOnInstance.aspx.cs" Inherits="CustomCacheCleanup.ClearHtmlCacheOnInstance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clear all HTML caches in specific Web App instance</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>The tool to clean up all HTML caches in the specific Web App instance</h1>
                <p>Provide the instance name by query string parameter. Your request should look like following</p>
                <p>
                    <pre>
                        <i>https://yourhostname/folderWhereAspxLocated/ClearHtmlCacheOnInstance.aspx?instanceName=INSTANCENAME</i>
                    </pre>
                    <span>You can find the instance names in the Kudu App. Thea are normally listed as computername environment variable</span>
                </p>
            </div>
            <div style="color: chocolate; background-color: blanchedalmond">
                <asp:Literal ID="StatusLiteral" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
