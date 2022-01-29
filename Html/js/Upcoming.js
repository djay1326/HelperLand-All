function dash(){
	var p = document.getElementById("DashboardTable");
	var aa =document.getElementById("ServiceHistoryTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
	// var aa = document.getElementById("Dif (x.style.display === "block") {
    p.style.display = "block";
    if(p.style.display === "block") {
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
    }
  	
}

function notifications(){
	var x = document.getElementById("NotificationsTable");
	var aa = document.getElementById("DashboardTable");
	var ab =document.getElementById("ServiceHistoryTable");
	var ac =document.getElementById("FavouriteProsTable");
	if (x.style.display === "none") {
    x.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
  	} 
  else {
    x.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    aa.style.display = "block";
  }
}

function history(){
	var y = document.getElementById("ServiceHistoryTable");
	var aa = document.getElementById("DashboardTable");
	var ab =document.getElementById("FavouriteProsTable");
	var ac = document.getElementById("NotificationsTable");
	if (y.style.display === "none") {
    y.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
  	} 
  else {
    y.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    aa.style.display = "block";
  }
}

function pros(){
	var z = document.getElementById("FavouriteProsTable");
	var aa = document.getElementById("DashboardTable");
	var ab = document.getElementById("ServiceHistoryTable");
	var ac = document.getElementById("NotificationsTable");
	if (z.style.display === "none") {
    z.style.display = "block";
    aa.style.display = "none";
    ab.style.display = "none";
    ac.style.display = "none";
  	} 
  else {
    z.style.display = "none";
    ac.style.display = "none";
    ab.style.display = "none";
    aa.style.display = "block";
  }
}

