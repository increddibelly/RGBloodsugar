# RGBloodsugar
Translate Bloodsugar information from Nightscout into RGB values on RGB capable hardware connected to your computer. Currently only logitech G series hardware is supported.

*requirements:*

for this tool to do anything useful, you...
- must own a Logitech G series device with RGB lighting capabilities.
- must download the Logitech G series SDK from https://www.logitechg.com/en-us/innovation/developer-lab.html (I can't redistribute those files, sorry)
  the zip file contains a LogitechLedEnginesWrapper.dll file, which needs to be in the same folder as the binaries from this project.
- must have installed the Logitech driver package (if you can run the tool that allows you to configure the lights on your Logitech G device, you're set)
- must know the url of a Nightscout website.

*usage:*

build the project, stick the binaries in a folder.
copy the LogitechLedEnginesWrapper.dll file into that same folder.
Run the executable from the command prompt and pass the Nightscout url as the command line parameter.
e.g. LogitechLedScout.exe http://www.github.com
the example will fail, since it's not a Nightscout site, but I'm sure you'll get the general idea.

It's even more convenient to create a shortcut to the executable and add the url to the command line parameters field in the shortcut.

*effects:*

when your bloodsugar is OK (4-9mmol/l or 72-162UnitsOfAmerica) the device's leds will be green.
when your bloodsugar is low, the device will turn blue; red for high blood sugars.
when your bloodsugar is rising (fast) or dropping (fast), the device will blink (fast)

*whut?*

let's say your blood sugar is 5, but you've just had a snack. 
within five minutes, the leds on your RGB mouse/keyboard/iWhatever will quickly blink yellow, telling you the bloodsugar is rising fast. After a couple blinks, the device will turn green, as current sugar level is still OK.

*What's a Nightscout*
http://www.lmgtfy.com/?q=nightscout
