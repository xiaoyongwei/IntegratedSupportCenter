<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataImport.aspx.cs" Inherits="工作数据分析Web_FineUI.WebPage.DataImportOutport.DataImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .result img {
            border: 1px solid #CCCCCC;
            max-width: 550px;
            padding: 3px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" IsFluid="true" CssClass="blockpanel" BodyPadding="10px" runat="server" EnableCollapse="false"
            ShowBorder="true" Title="上传数据" ShowHeader="true">
            <Items>                
                <f:FileUpload runat="server" ID="FileUploadZhibanRukuExcel" EmptyText="请选择上传的Excel" Label="纸板入库明细" Required="false" ButtonIcon="Add"
                    ShowRedStar="false" AutoPostBack="true" OnFileSelected="FileUploadZhibanRukuExcel_FileSelected">
                </f:FileUpload>
                 <f:FileUpload runat="server" ID="FileUploadZhibanKucunExcel" EmptyText="请选择上传的Excel" Label="纸板库存明细" Required="false" ButtonIcon="Add"
                    ShowRedStar="false" AutoPostBack="true" OnFileSelected="FileUploadZhibanKucunExcel_FileSelected">
                </f:FileUpload>
                <f:FileUpload runat="server" ID="FileUploadChejianBaogongExcel" EmptyText="请选择上传的Excel" Label="车间报工" Required="false" ButtonIcon="Add"
                    ShowRedStar="false" AutoPostBack="true" OnFileSelected="FileUploadChejianBaogongExcel_FileSelected">
                </f:FileUpload>
                  <f:FileUpload runat="server" ID="FileUploadChengpinRukuExcel" EmptyText="请选择上传的Excel" Label="成品入库" Required="false" ButtonIcon="Add"
                    ShowRedStar="false" AutoPostBack="true" OnFileSelected="FileUploadChengpinRukuExcel_FileSelected">
                </f:FileUpload>
                <%--<f:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1"
                    Text="提交">
                </f:Button>--%>
            </Items>
        </f:SimpleForm>
        <f:Label ID="labResult" CssClass="result" EncodeText="false" runat="server">
        </f:Label>   
         
         </form>
    
</body>
</html>
