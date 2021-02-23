<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlKucun.ascx.cs" Inherits="工作数据分析Web_FineUI.WebUserControl.WebUserControl1" %>
<asp:Label ID="ShowKucun" runat="server" 
    Text="<%=OracleHelper.ExecuteScalar(
            "select '库存:'||round(sum(面积))||'平方, '||round(sum(金额))||'元' from(select t.accamt as 金额,round(t.invnum * t.acreage) as 面积"
            + " from v_bcdt_ct t where t.objtyp = 'CL'   and t.orgcde = 'KS03'   and t.clientid = 'KS' group by t.objtyp,"
            + "t.orgcde, t.clntnme, t.serial, t.mkpcde, t.ptdate, t.shdate, t.clntcde, t.specs, t.clientid, t.prdnme, t.sitloc,"
            + "t.invnum, t.prices, t.accamt, t.acreage, t.crrcde, t.matcde, t.remark)aa").ToString(); %>"></asp:Label>