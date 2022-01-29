function dash(){
	var p = document.getElementById("DashboardTable");
	var aa =document.getElementById("ServiceHistoryTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	// var aa = document.getElementById("Dif (x.style.display === "block") {
    p.style.display = "block";
    if(p.style.display === "block") {
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
    }
  	
}

function notifications(){
	var x = document.getElementById("NotificationsTable");
	var aa = document.getElementById("DashboardTable");
	var ab =document.getElementById("ServiceHistoryTable");
	var ac =document.getElementById("FavouriteProsTable");
  var m = document.getElementById("custSettings");
	if (x.style.display === "none") {
    x.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
  	} 
  else {
    x.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    m.style.display="none";
    aa.style.display = "block";
  }
}

function history(){
	var y = document.getElementById("ServiceHistoryTable");
	var aa = document.getElementById("DashboardTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	if (y.style.display === "none") {
    y.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
  	} 
  else {
    y.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    aa.style.display = "block";
    m.style.display="none";
  }
}

function pros(){
	var z = document.getElementById("FavouriteProsTable");
	var aa = document.getElementById("DashboardTable");
	var ab = document.getElementById("ServiceHistoryTable");
	var ac = document.getElementById("NotificationsTable");
  var m = document.getElementById("custSettings");
	if (z.style.display === "none") {
    z.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    m.style.display="none";
  	} 
  else {
    z.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    m.style.display="none";
    aa.style.display = "block";
  }
}
function settings(){
  var m = document.getElementById("custSettings");
  var p = document.getElementById("DashboardTable");
  var aa =document.getElementById("ServiceHistoryTable");
  var ab =document.getElementById("FavouriteProsTable");
  var ac = document.getElementById("NotificationsTable");
  if(m.style.display==="none"){
    m.style.display= "block";
    p.style.display ="none";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
  }
  else{
    m.style.display="none";
    p.style.display ="block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
  }
}

// .......sidenav...........

function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}

// for sticky navbar

window.onscroll = function() {
  if (window.pageYOffset > 100) {
    document.getElementById("navbar11").classList.add('scrolled');
    document.getElementById("navbar11").classList.add('fixed-top');
    document.getElementById("imgg2").setAttribute("src","images/small.png");
  } 
  else {
    document.getElementById("navbar11").classList.remove('scrolled');
    document.getElementById("navbar11").classList.remove('fixed-top');
    document.getElementById("imgg2").setAttribute("src","images/large.png");
  } 
}