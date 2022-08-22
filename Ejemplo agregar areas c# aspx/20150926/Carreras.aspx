<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carreras.aspx.cs" Inherits="_20150926.Carreras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Carreras</h2>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/Areas.aspx" Text="Areas" Value="Areas">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Carreras.aspx" Text="Carreras" Value="Carreras">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <hr />
        <asp:GridView ID="GvCarreras" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="OdsCarreras" 
            EmptyDataText="No hay carreras ingresadas en el sistema" DataKeyNames="CarreraID">
            <Columns>
            <asp:TemplateField HeaderText="N°">
                    <ItemTemplate>
                        <span><%#Container.DataItemIndex+1 %></span>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Duracion" HeaderText="Duración" 
                    SortExpression="Duracion" />
                <asp:TemplateField HeaderText="Area" SortExpression="AreaID">
                    <EditItemTemplate>
                        <asp:DropDownList ID="TxtEditArea" runat="server" DataSourceID="OdsAreas" 
                            DataTextField="Nombre" DataValueField="AreaID" 
                            SelectedValue='<%# Bind("AreaID", "{0}") %>'>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Area.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="OdsCarreras" runat="server" DeleteMethod="Borrar" 
            OldValuesParameterFormatString="{0}" SelectMethod="ObtenerCarreras" 
            TypeName="_20150926.BLL.CarreraBLL" UpdateMethod="Editar">
            <DeleteParameters>
                <asp:Parameter Name="CarreraID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Duracion" Type="Int32" />
                <asp:Parameter Name="AreaID" Type="Int32" />
                <asp:Parameter Name="CarreraID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <br />

        <fieldset>
            <legend>Nueva Carrera</legend>
            <div>Nombre</div>
            <div><asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></div>
            <div>Duración</div>
            <div><asp:TextBox ID="TxtDuracion" runat="server"></asp:TextBox></div>
            <div>Area</div>
            <div>
                <asp:DropDownList ID="DlArea" runat="server" DataSourceID="OdsAreas" 
                    DataTextField="Nombre" DataValueField="AreaID"></asp:DropDownList>
                <asp:ObjectDataSource ID="OdsAreas" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerAreas" 
                    TypeName="_20150926.BLL.AreaBLL"></asp:ObjectDataSource>
            </div>
            <div><asp:Button ID="BtnAgregar" runat="server" Text="Agregar Carrera" 
                    OnClick="BtnAgregar_Click" /></div>
        </fieldset>
    </div>
    </form>
</body>
</html>
