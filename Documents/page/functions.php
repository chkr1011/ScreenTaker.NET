<?php
function showHead($index = false) {
	$base = '<base href="http://czaplewski.name/screentaker/';
	$base .= $index ? '"/>' : 'dokumentation/"/>';
	
	$prefix = $index ? "dokumentation/" : "";
	
	echo '<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
	"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xml:lang="de" xmlns="http://www.w3.org/1999/xhtml">
	<head>
		' . $base . '
		<link rel="stylesheet" type="text/css" href="'.$prefix.'css/main.css" media="Screen,Projection,TV" />
		<meta name="author" content="Witold Czaplewski"/>
		<meta http-equiv="expires" content="0"/>
		<meta http-equiv="content-type" content="text/html; charset=utf-8"/>
		<meta name="copyright" content="Copyright C 2007 Witold Czaplewski"/>
		<meta name="description" content="Screentaker.NET ist ein frei verfügbares unter der GNU General Public License stehendes Werkzeug zur Erstellung, Speicherung sowie Weitergabe von Screenshots"/>
		<meta name="keywords" content="Screentaker.NET, Screenshots, Bilder, Upload, OpenSource, C#, Windows, Vista, Benutzerhandbuch, Dokumentation"/>
		<meta name="robots" content="index, follow"/>
		<title>Willkommen bei Screentaker.NET - Screenshots schnell &#38; einfach</title>
	</head>
	<body dir="ltr">
		<div id="head">
			<div id="logo"><img alt="Logo" src="'.$prefix.'img/logo.png"/></div>
			<h1><a href="http://czaplewski.name/screentaker" title="Screentaker.NET Startseite">Screentaker.NET</a> - Screenshots schnell &#38; einfach</h1>
			<em style="color: yellow">Bitte beachten Sie, dass sich diese Seite noch im Aufbau befindet. Es könnte somit vorkommen, dass einige Seiten noch nicht vollständig sind.</em>
		</div>
';
}

function showFoot() {
echo'		<div id="footer">
			<p>
				&copy; 2007 Witold Czaplewski &amp; Christian Kratky |
				<a href="http://czaplewski.name/screentaker" title="Screentaker.NET Startseite">Startseite</a> |
				<a href="http://czaplewski.name/screentaker/dokumentation" title="Screentaker.NET Dokumentation">Dokumentation</a> |
				<a href="http://czaplewski.name/screentaker/dokumentation/impressum.html" title="Screentaker.NET Impressum">Impressum</a> |
				<a href="http://www.validome.org/referer" title="HTML / XHTML / WML / XML Validator">XHTML 1.1</a> |
				<a href="http://jigsaw.w3.org/css-validator/check/referer">CSS 3</a>
			</p>
		</div>
';
}