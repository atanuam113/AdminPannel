<%@ Page Language="C#" Title="Login Page" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdminPannel.Login" MasterPageFile="~/Site.Master"%>



   <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <%--<form id="form1" runat="server">--%>
     <div class="container">
        <div class="loginpage" style="height: 40px">
            <label for="validationServer02" class="form-label">username</label>
            <asp:TextBox ID="txtusername" runat="server" placeholder="Enter your username" Height="20px"></asp:TextBox>
        </div><br />
     

        <div style="height: 39px; width: 965px;">
            <label for="validationServer02" class="form-label">Password</label>
            <asp:TextBox ID="txtpassword" placeholder="Enter your password"  runat="server" Height="20px" TextMode="Password"></asp:TextBox>
        </div><br />
       
    
        <div style="height: 36px">
            <asp:Button ID="loginbtn" runat="server" Text="Login" BackColor="#0099FF" ForeColor="White" Height="30px" Width="76px" OnClick="Button1_Click" /> <br />
        </div>

        <div style="height: 42px">
            <asp:Label ID="Label1" runat="server" Text="Don&#39;t Have An Account ? "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Register Now</asp:HyperLink>
            <br />
        </div>

         <div>
             <asp:Label ID="txterroemsg" runat="server" Text=""></asp:Label>

         </div>

     </div>

  </asp:Content>

