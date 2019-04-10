module Tests

open Xunit
open RomanNumerals
open RomanNumeralProperties
open FsCheck

// "Normal" tests for roman numerals
[<Fact>]
let ``Test that 497 is CDXCVII`` () =
    let expected = "CDXCVII"
    let actual = RomanNumerals.arabicToRoman 497
    Assert.Equal(expected, actual)

// Properties

module Helpers =
    // Helper function - let's limit the input size to 4000
    let testWithRange f num = 
        // Set up a filter
        let romanIsInRange i = (i >= 1) && (i <= 4000)

        // If number is in range then check the property 
        romanIsInRange num ==> lazy (f num)

// Verifiable property
[<Fact>]
let ``Test that roman numerals have no more than one V`` () =
    let prop num =
        RomanNumerals.arabicToRoman num
        |> RomanNumeralProperties.``has max rep of one V``

    Check.Quick (Helpers.testWithRange prop)

// Falsifiable property
[<Fact>]
let ``Test that roman numerals have no more than two Xs``() = 
    // a property that does NOT hold for all roman numerals
    let hasMaxRepitionofTwoXs roman = 
        maxRepetitionProperty "X" 2 roman 

    let prop num = 
        // convert the number to roman and check the property
        RomanNumerals.arabicToRoman num
        |> hasMaxRepitionofTwoXs

    Check.Quick (Helpers.testWithRange prop)