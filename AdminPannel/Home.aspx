<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdminPannel.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div id="CURDPage" style="margin-top: 25px; margin-bottom: 43px">
        <asp:GridView ID="EmpPersonalDetails" runat="server"
        AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="EmployeeId"
        onRowCommand="EmpPersonalDetails_RowCommand" OnRowEditing="EmpPersonalDetails_RowEditing" 
        OnRowCancelingEdit="EmpPersonalDetails_RowCancelingEdit"
        OnRowUpdating="EmpPersonalDetails_RowUpdating" OnRowDeleting="EmpPersonalDetails_RowDeleting"
        
        CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="210px" Width="598px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />


        <Columns>
                <%--FirstName--%>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FirstName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFirstNameFooter" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--LastName--%>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastNameFooter" runat="server"></asp:TextBox>
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
              
                <%--CRUD Operation Column--%>
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
            </Columns>
    </asp:GridView>
        
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Index.aspx">Insert Bulk Of Data</asp:HyperLink>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log Out" />
    </div>
        <%--Success & Faild Field--%>
        <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
        <div>
        </div>
  
</asp:Content>
