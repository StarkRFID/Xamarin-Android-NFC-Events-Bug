# Xamarin-Android-NFC-Events-Bug
Public repo for sharing the sample code that exhibits the NFC intent/events bug we've experienced.

Scanning an NFC Tag in a Xamarin Android applications appears to trigger events such as `OnAppearing` for pages that are not being displayed on the device.

### Steps to Reproduce:
- Pull this repo and run the solution that it contains.
- Run application on an Android device while attached to the debugger.
- Navigate to the `ScanPage` by tapping the button on the `AboutPage`.
- _Optionally navigate to `AnotherScanPage` by tapping the button on the `ScanPage`._
- Once on the `ScanPage` or `AnotherScanPage`, scan an NFC tag and notice that `AboutPage.OnAppearing` is executed while scanning the tag.

### Other Info
We've noticed that the page at the "bottom" of the NavigationStack seems to be the page for which the unexpected events will trigger.
