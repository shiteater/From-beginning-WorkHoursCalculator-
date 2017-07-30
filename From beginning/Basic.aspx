﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Basic.aspx.cs" Inherits="From_beginning.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <asp:TextBox ID="TbxWorkedHouresOnThisDay" runat="server" Width="180px">Worked Houres On This Day</asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" style="top: 23px; left: 1100px; float: right; height: 188px; width: 513px;" SelectedDate="<%# DateTime.Today %>" >
        <SelectedDayStyle BackColor="#6699FF" />
        <TodayDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    <br />
    <br />
    <br />
    <asp:TextBox ID="TbxHourPrice" runat="server" Width="180px">Hour price</asp:TextBox>
    <br />
    <br />
    Calculation for<asp:DropDownList ID="ddlMode" runat="server">
        <asp:ListItem>1 day</asp:ListItem>
        <asp:ListItem>1 week</asp:ListItem>
        <asp:ListItem>1 month</asp:ListItem>
        <asp:ListItem>a year</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:TextBox ID="TbxTotalHours" runat="server" Width="180px">Total Hours</asp:TextBox>
    &nbsp;<br />
    <br />
    <br />
    <asp:TextBox ID="TbxTotalEarnings" runat="server" Width="180px">Total Earnings</asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="BtnSaveChanges" runat="server" Text="SaveChanges" OnClick="BtnSaveChanges_Click" />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
