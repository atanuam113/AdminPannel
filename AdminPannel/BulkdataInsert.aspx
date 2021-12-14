<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BulkdataInsert.aspx.cs" Inherits="AdminPannel.BulkdataInsert" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter the number of row you want to insert"></asp:Label>
        <asp:TextBox ID="NoOfRow" runat="server"></asp:TextBox>
        <asp:Button ID="btnAddrow" runat="server" Text="Add Rows" OnClick="btnAddrow_Click" />
        <br />
    </div>
    <div>

        <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false">
            <Columns>

                <asp:TemplateField HeaderText="Emp No.">
                    <ItemTemplate>
                        <%#Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Employee name">
                    <ItemTemplate>
                        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Employee Email">
                    <ItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Employee Phone No.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <br />
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

            <br />

        </asp:Panel>
    </div>
    <div>
        <b>DataBase Records are Shown Below</b>
        <div>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>

                        <asp:TemplateField HeaderText="Emp No.">
                            <ItemTemplate>
                                <%#Eval("Id") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Employee name">
                            <ItemTemplate>
                                <%#Eval("E_Name") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Email">
                            <ItemTemplate>
                                <%#Eval("E_Email") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Phone No.">
                            <ItemTemplate>
                                <%#Eval("E_Phone") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
          </div>
    
    </div>
    

</asp:Content>
