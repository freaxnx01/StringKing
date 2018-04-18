using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringKing.FunctionInterface
{
    public class StringFunctionBase : IStringFunction
    {
        #region IStringFunction
        public virtual string ExecuteFunction(string[] input, Dictionary<string, object> arguments)
        {
            return string.Empty;
        }

        public virtual Dictionary<string, object> GetListOfArgument()
        {
            return new Dictionary<string, object>();
        }

        public virtual string GetTestString()
        {
            return GetTestData();
        }

        public string GetLoremIpsumString()
        {
            return "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
        }

        public string GetDisplayName()
        {
            object[] customAttributes = this.GetType().GetCustomAttributes(typeof(StringFunctionAttribute), false);
            if (customAttributes.Length == 1)
            {
                return ((StringFunctionAttribute)customAttributes[0]).DisplayName;
            }
            return string.Empty;
        }

        public string GetCallAsString(Dictionary<string, object> arguments)
        {
            // TODO: Behandlung von ' in strings

            StringBuilder sb = new StringBuilder();
            sb.Append(GetDisplayName());
            sb.Append("(");

            int argCounter = 0;
            foreach (object argObject in arguments.Values)
            {
                if (argObject != null)
                {
                    StringFunctionArgument arg = (StringFunctionArgument)argObject;

                    if (arg.Value != null)
                    {
                        int result;
                        if (int.TryParse(arg.Value.ToString(), out result))
                        {
                            sb.Append(arg.Value);
                        }
                        else
                        {
                            sb.Append(string.Format("\"{0}\"", arg.Value));
                        }
                    }
                }

                if (argCounter + 1 < arguments.Count)
                {
                    sb.Append(", ");
                }
                argCounter++;
            }

            sb.Append(")");

            return sb.ToString();
        }
        #endregion

        #region Helpers
        protected object GetArgumentValue(Dictionary<string, object> arguments, string argumentName)
        {
            if (arguments.ContainsKey(argumentName))
            {
                if (arguments[argumentName] is StringFunctionArgument)
                {
                    return ((StringFunctionArgument)arguments[argumentName]).Value;
                }
            }

            return null;
        }

        protected string ConvertListToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in list)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }

        protected List<string> SplitByNewLine(string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        protected List<string> SplitByNewLine(string input, bool preserveEmptyLines)
        {
            if (!preserveEmptyLines)
            {
                return SplitByNewLine(input);
            }

            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        }
        #endregion

        #region TestData
        protected string GetTestData()
        {
            return @"UNS
agr64svc
OUTLOOK
svchost
smss
WmiPrvSE
taskhost
mfevtps
services
unsecapp
MSBuild
mcshield
Skype
HPDrvMntSvc
svchost
lsm
WUDFHost
svchost
atieclxx
lsass
csrss
DPAgent
NetworkLicenseServer
jhi_service
LSSrvc
CCC
svchost
dwm
SynTPEnh
hamachi-2
NKRexec
FlashPlayerPlugin_11_3_300_257
INUserInfoClient
svchost
HPFSService
IAStorDataMgrSvc
GoogleCalendarSync
firefox
plugin-container
conhost
TSVNCache
hpCMSrv
InserterEE
svchost
svchost
svchost
dtpd
WLIDSVCM
UdaterUI
HPSA_Service
wuauclt
ipsecd
Ditto
MSBuild
splwow64
DpHostW
SearchProtocolHost
DpAgent
hpservice
svchost
VsTskMgr
mfeann
winlogon
IAStorIcon
FlashPlayerPlugin_11_5_502_110
FlashPlayerPlugin_11_5_502_110
stacsv64
MOM
DTSRVC
Roslyn.Services.dll
pdisrvc
FlashPlayerPlugin_11_3_300_257
OSPPSVC
explorer
LMS
conhost
svchost
naPrdMgr
McTray
svchost
InpidGui_2
iked
plugin-container
PresentationFontCache
HPPA_Main
conhost
devenv
wininit
MSBuild
msvsmon
WUDFHost
armsvc
csrss
nusb3mon
hpqWmiEx
svchost
FrameworkService
taskeng
sqlwriter
HPPA_Service
StringKing.vshost
WLIDSVC
conhost
SDKCOMServer
AESTSr64
taskmgr
conhost
SearchIndexer
HPConnectionManager
hpmup091.bin
SynTPHelper
Dropbox
uArcCapture
vcsFPService
hpHotkeyMonitor
wmpnetwk
EpePcMonitor
SearchFilterHost
MfeEpeHost
dtsslsrv
svchost
fdm
mini_WMCore
spoolsv
svchost
atiesrxx
MSBuildTaskHost
ObjectStudio
System
sidebar
Idle";
        }

        protected string GetPathTestData()
        {
            return @"C:\windows\system32\AdapterTroubleshooter.exe
C:\windows\system32\aitagent.exe
C:\windows\system32\alg.exe
C:\windows\system32\appidcertstorecheck.exe
C:\windows\system32\appidpolicyconverter.exe
C:\windows\system32\appverif.exe
C:\windows\system32\ARP.EXE
C:\windows\system32\at.exe
C:\windows\system32\AtBroker.exe
C:\windows\system32\atiapfxx.exe
C:\windows\system32\atibtmon.exe
C:\windows\system32\atieclxx.exe
C:\windows\system32\atiesrxx.exe
C:\windows\system32\ATIODCLI.exe
C:\windows\system32\ATIODE.exe
C:\windows\system32\attrib.exe
C:\windows\system32\audiodg.exe
C:\windows\system32\auditpol.exe
C:\windows\system32\autochk.exe
C:\windows\system32\autoconv.exe
C:\windows\system32\autofmt.exe
C:\windows\system32\AxInstUI.exe
C:\windows\system32\bcdboot.exe
C:\windows\system32\bcdedit.exe
C:\windows\system32\BdeUISrv.exe
C:\windows\system32\BdeUnlockWizard.exe
C:\windows\system32\bitsadmin.exe
C:\windows\system32\bootcfg.exe
C:\windows\system32\bridgeunattend.exe
C:\windows\system32\bthudtask.exe
C:\windows\system32\cacls.exe
C:\windows\system32\calc.exe
C:\windows\system32\CertEnrollCtrl.exe
C:\windows\system32\certreq.exe
C:\windows\system32\certutil.exe
C:\windows\system32\change.exe
C:\windows\system32\charmap.exe
C:\windows\system32\chglogon.exe
C:\windows\system32\chgport.exe
C:\windows\system32\chgusr.exe
C:\windows\system32\chkdsk.exe
C:\windows\system32\chkntfs.exe
C:\windows\system32\choice.exe
C:\windows\system32\cipher.exe
C:\windows\system32\cleanmgr.exe
C:\windows\system32\cliconfg.exe
C:\windows\system32\clip.exe
C:\windows\system32\cmd.exe
C:\windows\system32\cmdkey.exe
C:\windows\system32\cmdl32.exe
C:\windows\system32\cmmon32.exe
C:\windows\system32\cmstp.exe
C:\windows\system32\cofire.exe
C:\windows\system32\colorcpl.exe
C:\windows\system32\comp.exe
C:\windows\system32\compact.exe
C:\windows\system32\CompMgmtLauncher.exe
C:\windows\system32\ComputerDefaults.exe
C:\windows\system32\conhost.exe
C:\windows\system32\consent.exe
C:\windows\system32\control.exe
C:\windows\system32\convert.exe
C:\windows\system32\credwiz.exe
C:\windows\system32\cscript.exe
C:\windows\system32\csrss.exe
C:\windows\system32\ctfmon.exe
C:\windows\system32\cttune.exe
C:\windows\system32\cttunesvr.exe
C:\windows\system32\dccw.exe
C:\windows\system32\dcomcnfg.exe
C:\windows\system32\ddodiag.exe
C:\windows\system32\Defrag.exe
C:\windows\system32\DeviceDisplayObjectProvider.exe
C:\windows\system32\DeviceEject.exe
C:\windows\system32\DevicePairingWizard.exe
C:\windows\system32\DeviceProperties.exe
C:\windows\system32\DFDWiz.exe
C:\windows\system32\dfrgui.exe
C:\windows\system32\dialer.exe
C:\windows\system32\diantz.exe
C:\windows\system32\dinotify.exe
C:\windows\system32\diskpart.exe
C:\windows\system32\diskperf.exe
C:\windows\system32\diskraid.exe
C:\windows\system32\Dism.exe
C:\windows\system32\dispdiag.exe
C:\windows\system32\DisplaySwitch.exe
C:\windows\system32\djoin.exe
C:\windows\system32\dllhost.exe
C:\windows\system32\dllhst3g.exe
C:\windows\system32\dnscacheugc.exe
C:\windows\system32\doskey.exe
C:\windows\system32\dpapimig.exe
C:\windows\system32\DpiScaling.exe
C:\windows\system32\dpnsvr.exe
C:\windows\system32\driverquery.exe
C:\windows\system32\drvinst.exe
C:\windows\system32\dvdplay.exe
C:\windows\system32\dvdupgrd.exe
C:\windows\system32\dwm.exe
C:\windows\system32\DWWIN.EXE
C:\windows\system32\dxcpl.exe
C:\windows\system32\dxdiag.exe
C:\windows\system32\Dxpserver.exe
C:\windows\system32\Eap3Host.exe
C:\windows\system32\efsui.exe
C:\windows\system32\EhStorAuthn.exe
C:\windows\system32\esentutl.exe
C:\windows\system32\eudcedit.exe
C:\windows\system32\eventcreate.exe
C:\windows\system32\eventvwr.exe
C:\windows\system32\expand.exe
C:\windows\system32\extrac32.exe
C:\windows\system32\fc.exe
C:\windows\system32\find.exe
C:\windows\system32\findstr.exe
C:\windows\system32\finger.exe
C:\windows\system32\fixmapi.exe
C:\windows\system32\fltMC.exe
C:\windows\system32\fontview.exe
C:\windows\system32\forfiles.exe
C:\windows\system32\fsquirt.exe
C:\windows\system32\fsutil.exe
C:\windows\system32\ftp.exe
C:\windows\system32\fvenotify.exe
C:\windows\system32\fveprompt.exe
C:\windows\system32\FXSCOVER.exe
C:\windows\system32\FXSSVC.exe
C:\windows\system32\FXSUNATD.exe
C:\windows\system32\getmac.exe
C:\windows\system32\GettingStarted.exe
C:\windows\system32\gpresult.exe
C:\windows\system32\gpscript.exe
C:\windows\system32\gpupdate.exe
C:\windows\system32\grpconv.exe
C:\windows\system32\hdwwiz.exe
C:\windows\system32\help.exe
C:\windows\system32\HOSTNAME.EXE
C:\windows\system32\hpservice.exe
C:\windows\system32\hwrcomp.exe
C:\windows\system32\hwrreg.exe
C:\windows\system32\icacls.exe
C:\windows\system32\icardagt.exe
C:\windows\system32\icsunattend.exe
C:\windows\system32\IDTNGUI.exe
C:\windows\system32\IDTNJ.exe
C:\windows\system32\ie4uinit.exe
C:\windows\system32\ieUnatt.exe
C:\windows\system32\iexpress.exe
C:\windows\system32\InfDefaultInstall.exe
C:\windows\system32\ipconfig.exe
C:\windows\system32\irftp.exe
C:\windows\system32\iscsicli.exe
C:\windows\system32\iscsicpl.exe
C:\windows\system32\isoburn.exe
C:\windows\system32\java.exe
C:\windows\system32\javaw.exe
C:\windows\system32\javaws.exe
C:\windows\system32\klist.exe
C:\windows\system32\ksetup.exe
C:\windows\system32\ktmutil.exe
C:\windows\system32\label.exe
C:\windows\system32\LocationNotifications.exe
C:\windows\system32\Locator.exe
C:\windows\system32\lodctr.exe
C:\windows\system32\logagent.exe
C:\windows\system32\logman.exe
C:\windows\system32\logoff.exe
C:\windows\system32\LogonUI.exe
C:\windows\system32\lpksetup.exe
C:\windows\system32\lpremove.exe
C:\windows\system32\lsass.exe
C:\windows\system32\lsm.exe
C:\windows\system32\Magnify.exe
C:\windows\system32\makecab.exe
C:\windows\system32\manage-bde.exe
C:\windows\system32\mblctr.exe
C:\windows\system32\mcbuilder.exe
C:\windows\system32\mctadmin.exe
C:\windows\system32\MdRes.exe
C:\windows\system32\MdSched.exe
C:\windows\system32\mfevtps.exe
C:\windows\system32\mfpmp.exe
C:\windows\system32\microsoft.windows.softwarelogo.showdesktop.exe
C:\windows\system32\MigAutoPlay.exe
C:\windows\system32\mmc.exe
C:\windows\system32\mobsync.exe
C:\windows\system32\mountvol.exe
C:\windows\system32\mpnotify.exe
C:\windows\system32\MpSigStub.exe
C:\windows\system32\MRINFO.EXE
C:\windows\system32\MRT.exe
C:\windows\system32\msconfig.exe
C:\windows\system32\msdt.exe
C:\windows\system32\msdtc.exe
C:\windows\system32\msfeedssync.exe
C:\windows\system32\msg.exe
C:\windows\system32\mshta.exe
C:\windows\system32\msiexec.exe
C:\windows\system32\msinfo32.exe
C:\windows\system32\mspaint.exe
C:\windows\system32\msra.exe
C:\windows\system32\mstsc.exe
C:\windows\system32\mtstocom.exe
C:\windows\system32\MuiUnattend.exe
C:\windows\system32\MultiDigiMon.exe
C:\windows\system32\NAPSTAT.EXE
C:\windows\system32\Narrator.exe
C:\windows\system32\nbtstat.exe
C:\windows\system32\ndadmin.exe
C:\windows\system32\net.exe
C:\windows\system32\net1.exe
C:\windows\system32\netbtugc.exe
C:\windows\system32\netcfg.exe
C:\windows\system32\netiougc.exe
C:\windows\system32\Netplwiz.exe
C:\windows\system32\NetProj.exe
C:\windows\system32\netsh.exe
C:\windows\system32\NETSTAT.EXE
C:\windows\system32\newdev.exe
C:\windows\system32\nltest.exe
C:\windows\system32\notepad.exe
C:\windows\system32\nslookup.exe
C:\windows\system32\ntoskrnl.exe
C:\windows\system32\ntprint.exe
C:\windows\system32\ocsetup.exe
C:\windows\system32\odbcad32.exe
C:\windows\system32\odbcconf.exe
C:\windows\system32\openfiles.exe
C:\windows\system32\OptionalFeatures.exe
C:\windows\system32\osk.exe
C:\windows\system32\p2phost.exe
C:\windows\system32\PATHPING.EXE
C:\windows\system32\pcalua.exe
C:\windows\system32\pcaui.exe
C:\windows\system32\pcawrk.exe
C:\windows\system32\pcwrun.exe
C:\windows\system32\perfmon.exe
C:\windows\system32\PING.EXE
C:\windows\system32\PkgMgr.exe
C:\windows\system32\plasrv.exe
C:\windows\system32\PnPUnattend.exe
C:\windows\system32\PnPutil.exe
C:\windows\system32\poqexec.exe
C:\windows\system32\powercfg.exe
C:\windows\system32\PresentationHost.exe
C:\windows\system32\PresentationSettings.exe
C:\windows\system32\prevhost.exe
C:\windows\system32\print.exe
C:\windows\system32\PrintBrmUi.exe
C:\windows\system32\printfilterpipelinesvc.exe
C:\windows\system32\PrintIsolationHost.exe
C:\windows\system32\printui.exe
C:\windows\system32\proquota.exe
C:\windows\system32\PROUnstl.exe
C:\windows\system32\psr.exe
C:\windows\system32\PushPrinterConnections.exe
C:\windows\system32\qappsrv.exe
C:\windows\system32\qprocess.exe
C:\windows\system32\query.exe
C:\windows\system32\quser.exe
C:\windows\system32\qwinsta.exe
C:\windows\system32\rasautou.exe
C:\windows\system32\rasdial.exe
C:\windows\system32\raserver.exe
C:\windows\system32\rasphone.exe
C:\windows\system32\rdpclip.exe
C:\windows\system32\rdrleakdiag.exe
C:\windows\system32\rdrmemptylst.exe
C:\windows\system32\ReAgentc.exe
C:\windows\system32\recdisc.exe
C:\windows\system32\recover.exe
C:\windows\system32\reg.exe
C:\windows\system32\regedt32.exe
C:\windows\system32\regini.exe
C:\windows\system32\Register-CimProvider.exe
C:\windows\system32\RegisterIEPKEYs.exe
C:\windows\system32\regsvr32.exe
C:\windows\system32\rekeywiz.exe
C:\windows\system32\relog.exe
C:\windows\system32\RelPost.exe
C:\windows\system32\repair-bde.exe
C:\windows\system32\replace.exe
C:\windows\system32\reset.exe
C:\windows\system32\resmon.exe
C:\windows\system32\RMActivate.exe
C:\windows\system32\RMActivate_isv.exe
C:\windows\system32\RMActivate_ssp.exe
C:\windows\system32\RMActivate_ssp_isv.exe
C:\windows\system32\RmClient.exe
C:\windows\system32\Robocopy.exe
C:\windows\system32\ROUTE.EXE
C:\windows\system32\RpcPing.exe
C:\windows\system32\rrinstaller.exe
C:\windows\system32\rstrui.exe
C:\windows\system32\runas.exe
C:\windows\system32\rundll32.exe
C:\windows\system32\RunLegacyCPLElevated.exe
C:\windows\system32\runonce.exe
C:\windows\system32\rwinsta.exe
C:\windows\system32\sbunattend.exe
C:\windows\system32\sc.exe
C:\windows\system32\schtasks.exe
C:\windows\system32\sdbinst.exe
C:\windows\system32\sdchange.exe
C:\windows\system32\sdclt.exe
C:\windows\system32\sdiagnhost.exe
C:\windows\system32\SearchFilterHost.exe
C:\windows\system32\SearchIndexer.exe
C:\windows\system32\SearchProtocolHost.exe
C:\windows\system32\SecEdit.exe
C:\windows\system32\secinit.exe
C:\windows\system32\services.exe
C:\windows\system32\sethc.exe
C:\windows\system32\SetIEInstalledDate.exe
C:\windows\system32\setspn.exe
C:\windows\system32\setupcl.exe
C:\windows\system32\setupugc.exe
C:\windows\system32\setx.exe
C:\windows\system32\sfc.exe
C:\windows\system32\shadow.exe
C:\windows\system32\shrpubw.exe
C:\windows\system32\shutdown.exe
C:\windows\system32\sigverif.exe
C:\windows\system32\slui.exe
C:\windows\system32\smss.exe
C:\windows\system32\SndVol.exe
C:\windows\system32\SnippingTool.exe
C:\windows\system32\snmptrap.exe
C:\windows\system32\sort.exe
C:\windows\system32\SoundRecorder.exe
C:\windows\system32\spinstall.exe
C:\windows\system32\spoolsv.exe
C:\windows\system32\sppsvc.exe
C:\windows\system32\spreview.exe
C:\windows\system32\srdelayed.exe
C:\windows\system32\StikyNot.exe
C:\windows\system32\subst.exe
C:\windows\system32\svchost.exe
C:\windows\system32\sxstrace.exe
C:\windows\system32\SyncHost.exe
C:\windows\system32\syskey.exe
C:\windows\system32\systeminfo.exe
C:\windows\system32\SystemPropertiesAdvanced.exe
C:\windows\system32\SystemPropertiesComputerName.exe
C:\windows\system32\SystemPropertiesDataExecutionPrevention.exe
C:\windows\system32\SystemPropertiesHardware.exe
C:\windows\system32\SystemPropertiesPerformance.exe
C:\windows\system32\SystemPropertiesProtection.exe
C:\windows\system32\SystemPropertiesRemote.exe
C:\windows\system32\systray.exe
C:\windows\system32\tabcal.exe
C:\windows\system32\takeown.exe
C:\windows\system32\TapiUnattend.exe
C:\windows\system32\taskeng.exe
C:\windows\system32\taskhost.exe
C:\windows\system32\taskkill.exe
C:\windows\system32\tasklist.exe
C:\windows\system32\taskmgr.exe
C:\windows\system32\tcmsetup.exe
C:\windows\system32\TCPSVCS.EXE
C:\windows\system32\telnet.exe
C:\windows\system32\timeout.exe
C:\windows\system32\TpmInit.exe
C:\windows\system32\tracerpt.exe
C:\windows\system32\TRACERT.EXE
C:\windows\system32\tscon.exe
C:\windows\system32\tsdiscon.exe
C:\windows\system32\tskill.exe
C:\windows\system32\TSTheme.exe
C:\windows\system32\TsUsbRedirectionGroupPolicyControl.exe
C:\windows\system32\TSWbPrxy.exe
C:\windows\system32\TsWpfWrp.exe
C:\windows\system32\typeperf.exe
C:\windows\system32\tzutil.exe
C:\windows\system32\ucsvc.exe
C:\windows\system32\UI0Detect.exe
C:\windows\system32\unlodctr.exe
C:\windows\system32\unregmp2.exe
C:\windows\system32\upnpcont.exe
C:\windows\system32\UserAccountControlSettings.exe
C:\windows\system32\userinit.exe
C:\windows\system32\Utilman.exe
C:\windows\system32\VaultCmd.exe
C:\windows\system32\VaultSysUi.exe
C:\windows\system32\vcsFPService.exe
C:\windows\system32\vds.exe
C:\windows\system32\vdsldr.exe
C:\windows\system32\verclsid.exe
C:\windows\system32\verifier.exe
C:\windows\system32\vmicsvc.exe
C:\windows\system32\vmsal.exe
C:\windows\system32\VMWindow.exe
C:\windows\system32\vpc.exe
C:\windows\system32\VPCSettings.exe
C:\windows\system32\VPCWizard.exe
C:\windows\system32\vsjitdebugger.exe
C:\windows\system32\vssadmin.exe
C:\windows\system32\VSSVC.exe
C:\windows\system32\w32tm.exe
C:\windows\system32\waitfor.exe
C:\windows\system32\wbadmin.exe
C:\windows\system32\wbengine.exe
C:\windows\system32\wecutil.exe
C:\windows\system32\WerFault.exe
C:\windows\system32\WerFaultSecure.exe
C:\windows\system32\wermgr.exe
C:\windows\system32\wevtutil.exe
C:\windows\system32\wextract.exe
C:\windows\system32\WFS.exe
C:\windows\system32\where.exe
C:\windows\system32\whoami.exe
C:\windows\system32\wiaacmgr.exe
C:\windows\system32\wiawow64.exe
C:\windows\system32\wimserv.exe
C:\windows\system32\WindowsAnytimeUpgrade.exe
C:\windows\system32\WindowsAnytimeUpgradeResults.exe
C:\windows\system32\WindowsAnytimeUpgradeui.exe
C:\windows\system32\wininit.exe
C:\windows\system32\winload.exe
C:\windows\system32\winlogon.exe
C:\windows\system32\winresume.exe
C:\windows\system32\winrs.exe
C:\windows\system32\winrshost.exe
C:\windows\system32\WinSAT.exe
C:\windows\system32\winver.exe
C:\windows\system32\wisptis.exe
C:\windows\system32\wksprt.exe
C:\windows\system32\wlanext.exe
C:\windows\system32\wlrmdr.exe
C:\windows\system32\wowreg32.exe
C:\windows\system32\WPDShextAutoplay.exe
C:\windows\system32\wpnpinst.exe
C:\windows\system32\write.exe
C:\windows\system32\wscript.exe
C:\windows\system32\WSManHTTPConfig.exe
C:\windows\system32\wsmprovhost.exe
C:\windows\system32\wsqmcons.exe
C:\windows\system32\wuapp.exe
C:\windows\system32\wuauclt.exe
C:\windows\system32\WUDFHost.exe
C:\windows\system32\wusa.exe
C:\windows\system32\xcopy.exe
C:\windows\system32\xpsrchvw.exe
C:\windows\system32\xwizard.exe";
        }
        #endregion
    }
}
