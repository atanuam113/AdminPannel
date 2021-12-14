<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeContactPage.aspx.cs" Inherits="AdminPannel.EmployeeContactPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Employee Contact Details"></asp:Label>
            <br />
            <asp:GridView ID="EmpInformation" runat="server" AutoGenerateColumns="true" CellPadding="4" DataKeyNames="Emp_Id" ShowFooter="True"
                 
        emptydatatext="No data in the data source."
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                   <%-- <asp:BoundField DataField="Emp_Id" HeaderText="Employee No" InsertVisible="False" ReadOnly="True" SortExpression="Emp_Id">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="E_Name" HeaderText="Employee Name" SortExpression="E_Name">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="E_Email" HeaderText="Employee Email" SortExpression="E_Email">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="E_Phone" HeaderText="Employee Phone" SortExpression="E_Phone">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                


                     <%--FullName--%>
                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FullName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFullName" Text='<%# Eval("FullName") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFullNameFooter" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--Email--%>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtEmailFooter" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--PhoneNumber--%>
                <asp:TemplateField HeaderText="PhoneNumber">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("PhoneNumber") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPhoneNumber" Text='<%# Eval("PhoneNumber") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhoneNumberFooter" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                </Columns>



                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeeDetailsConnectionString %>" SelectCommand="SELECT * FROM [Emp_Contact_Details]"></asp:SqlDataSource>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
