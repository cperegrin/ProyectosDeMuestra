<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="_20150926.Areas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Áreas</h2>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/Areas.aspx" Text="Areas" Value="Areas">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Carreras.aspx" Text="Carreras" Value="Carreras">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <hr />
        <asp:GridView ID="GvAreas" runat="server" AutoGenerateColumns="False" 
            DataSourceID="OdsAreas" AllowPaging="True" PageSize="5" 
            DataKeyNames="AreaID" EmptyDataText="No hay Areas ingresadas en el sistema">
            <Columns>
                <asp:TemplateField HeaderText="N°">
                    <ItemTemplate>
                        <span><%#Container.DataItemIndex+1 %></span>
                    </ItemTemplate>
                </asp:TemplateField>              
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Encargado" HeaderText="Encargado" 
                    SortExpression="Encargado" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="OdsAreas" runat="server" 
            OldValuesParameterFormatString="{0}" SelectMethod="ObtenerAreas" 
            TypeName="_20150926.BLL.AreaBLL" DeleteMethod="Borrar" 
            UpdateMethod="Editar">
            <DeleteParameters>
                <asp:Parameter Name="AreaID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Encargado" Type="String" />
                <asp:Parameter Name="AreaID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>

        <br />
        <fieldset>
            <legend>Nueva Area</legend>
            <div>Nombre:</div><div><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></div>
            <div>Encargado:</div><div><asp:TextBox ID="TxtEncargado" runat="server"></asp:TextBox></div>
            <div><asp:Button ID="BtnAgregarArea" runat="server" Text="Agregar Area" 
                    OnClick="BtnAgregarArea_Click" /></div>
        </fieldset>
    </div>
    </form>
</body>
</html>
