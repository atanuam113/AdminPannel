<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AdminPannel.Index" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="height: 40px">
        
        <button>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Home.aspx">Previous Page</asp:HyperLink></button>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log Out" />
    </div>

    <div>

        <asp:GridView ID="gvContacts" ShowFooter="true" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvContacts_SelectedIndexChanged">
            <Columns>

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
                     <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="Button3" runat="server" Text="Add Row" OnClick ="gvContacts_SelectedIndexChanged"/>

                    </FooterTemplate>
                </asp:TemplateField>
             
            </Columns>
        </asp:GridView>
        <br />

    </div>

    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="true">
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
                                <%#Eval("Emp_Id") %>
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

