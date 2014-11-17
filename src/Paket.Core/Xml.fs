﻿module Paket.Xml

open System.Xml

/// [omit]
let addAttribute name value (node:XmlElement) =
    node.SetAttribute(name, value) |> ignore
    node

/// [omit]
let addChild child (node:XmlElement) =
    node.AppendChild(child) |> ignore
    node

/// [omit]
let getAttribute name (node:XmlNode) =
    node.Attributes 
    |> Seq.cast<XmlAttribute> 
    |> Seq.tryFind (fun a -> a.Name = name) 
    |> Option.map (fun a -> a.Value)

/// [omit]
let optGetAttribute name node = node |> Option.bind (getAttribute name)

/// [omit]
let getNode name (node:XmlNode) =
    let xpath = sprintf "*[local-name() = '%s']" name
    match node.SelectSingleNode(xpath) with
    | null -> None
    | n -> Some(n)

/// [omit]
let optGetNode name node = node |> Option.bind (getNode name)

/// [omit]
let getNodes name (node:XmlNode) =
    let xpath = sprintf "*[local-name() = '%s']" name
    match node.SelectNodes(xpath) with
    | null -> []
    | nodeList -> 
        nodeList
        |> Seq.cast<XmlNode>
        |> Seq.toList

/// [omit]
let getDescendants name (node:XmlNode) = 
    let xpath = sprintf "//*[local-name() = '%s']" name
    match node.SelectNodes(xpath) with
    | null -> []
    | nodeList -> 
        nodeList
        |> Seq.cast<XmlNode>
        |> Seq.toList