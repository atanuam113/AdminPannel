<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AdminPannel._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    
      <div>
        <label for="validationServer01" class="form-label">Full name</label>
          <asp:TextBox ID="txtfullname" runat="server" placeholder="Enter your name"  Height="22px"></asp:TextBox>
      </div><br />

      <div>
        <label for="validationServer02" class="form-label">Email</label>
        <asp:TextBox ID="txtemail" runat="server"  Width="148px" placeholder="Enter your Email"></asp:TextBox>
    </div><br />

      <div>
        <label for="validationServer02" class="form-label">username</label>
          <asp:TextBox ID="txtusername" runat="server" placeholder="Set a username"></asp:TextBox>
    </div><br />
     

     <div>
        <label for="validationServer02" class="form-label">Password</label>
         <asp:TextBox ID="txtpassword" runat="server" Width="179px" TextMode="Password" placeholder="Create a Password"></asp:TextBox>
    </div><br />
     

     <div>
        <label for="validationServer02" class="form-label">Confirm Password</label>
         <asp:TextBox ID="txtcpassword" runat="server" placeholder="ReEnter your password"></asp:TextBox>
    </div><br />

    <div>
        <div class="form-check">
          <input class="form-check-input is-invalid" type="checkbox" value="" id="invalidCheck3" aria-describedby="invalidCheck3Feedback" required>
            <label class="form-check-label" for="invalidCheck3">
                Agree to terms and conditions
            </label>
            <div id="invalidCheck3Feedback" class="invalid-feedback">
             You must agree before submitting.
            </div>
        </div>
    </div>
    <div class="col-12">
        <asp:Button ID="txtsubmit" runat="server" Text="Register" BackColor="#337AB7" ForeColor="White" OnClick="txtsubmit_Click" />
        <br />
     </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Already Have an Account ?"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Sign In</asp:HyperLink>
      <br />
    </div>

</asp:Content>
