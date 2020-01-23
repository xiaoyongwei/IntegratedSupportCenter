using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;



namespace HanDe_ClassLibrary.PrinergyEvoFile.Preps
{
    public static class PrepsConfig
    {
        public static bool SetOpenJobPath(string path)
        {
            try
            {
                //string defaultFile=@"C:\Preps 5.3.2\Profiles\Default\default.cfg";

                string text = File.ReadAllText(path);

                //替换输出路径
                //Regex regex = new Regex(@"-WINOUTPATH\:.*");
                //Match match = regex.Match(text);
                //string oldStr=match.Value;
                //string newStr = @"-WINOUTPATH:" + objPath;
                //text = text.Replace(oldStr, newStr);

                //替换打开路径
                Regex regex = new Regex(@"-WINOPENJOBPATH\:.*");
                Match match = regex.Match(text);
                string oldStr = match.Value;
                string newStr = @"-WINOPENJOBPATH:" + path;
                text = text.Replace(oldStr, newStr);

                //写入文件
                File.WriteAllText(path, text);


                return true;
            }
            catch
            {
                return false;
            }


        }

        //public static bool Default()
        //{
        //    try
        //    {
        //    string defaultFile=@"C:\Preps 5.3.2\Profiles\Default\default.cfg";
        //    string defaultText =
        //             "-:Preps profile default"
        //            + "-WINPPDPATHS:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINPPDPATHS+:c:\\preps 5.3.2\\printers\\ppd\\"
        //            + "-WINOUTPATH:"
        //            + "-WINPREP1:"
        //            + "-WINPREP2:"
        //            + "-WINTEMP:C:\\Users\\ADMINI~1\\AppData\\Local\\Temp\\PrepsTemp\\"
        //            + "-WINADDFILESPATH:Y:\\Plate_Test\\PDF\\"
        //            + "-WINSAVEJOBPATH:"
        //            + "-WINOPENJOBPATH:" + string.Format("\\\\Evo28204\\JobData\\客户文件\\(88)\\{0}月\\{0}-{1}\\out", DateTime.Now.Month, DateTime.Now.Day)
        //            + "-AUTOREVERSE:NO"
        //            + "-AUTOCENTER:YES"
        //            + "-BLACKLIMIT:100.0000"
        //            + "-BORDER:36.0000"
        //            + "-BOXES:NO"
        //            + "-RIPDEBUGINFO:NO"
        //            + "-CENTER:YES"
        //            + "-SkipDeviceSizeWarning:NO"
        //            + "-CHARSET:PSDefault"
        //            + "-CLIPPAGES:NO"
        //            + "-CMYKKOCMYK:NO"
        //            + "-CMYKOPCMYK:NO"
        //            + "-CMYKKOSPOT:NO"
        //            + "-CMYKOPSPOT:NO"
        //            + "-COLATE:NO"
        //            + "-COMPENSATIONSETSPATH:"
        //            + "-COMPLAIN:NO"
        //            + "-DCS:YES"
        //            + "-EMBFONTSTRIPALL:NO"
        //            + "-EMBFONTMOVE:YES"
        //            + "-EMBFONTSTRIPINRIP:NO"
        //            + "-EMBFONTADDIFSTRIP:YES"
        //            + "-EMBFONTSTRIPDUPS:YES"
        //            + "-EMBFONTREPORTEXTERNALUSE:YES"
        //            + "-ENLARGE:NO"
        //            + "-EOL:CRLF"
        //            + "-FILMSAVER:YES"
        //            + "-FONTHANDLING:OFF"
        //            + "-FILEFORMATENCODING:134217984"
        //            + "-FORMBLEED:24.0000"
        //            + "-FREEHANDABOX:NO"
        //            + "-GROUP:YES"
        //            + "-GENERATEMULTIPAGECUTBLOCKS:YES"
        //            + "-GENERATECUTTINGDATA:NO"
        //            + "-CIP3MEASUREMENTUNITS:point"
        //            + "-PPFOUTPUTPATH:C:\\Preps 5.3.2\\Preps\\ppf\\"
        //            + "-INCFILE:YES"
        //            + "-INDEXAPP:NO"
        //            + "-INDEXEPS:NO"
        //            + "-INTBUFFERSIZE:2047"
        //            + "-PRINTIDLE:15"
        //            + "-MANDUPLEX:NO"
        //            + "-IGNOREBBOX:NO"
        //            + "-BLEEDCROP:YES"
        //            + "-DRAGONFLY:NO"
        //            + "-DRAGONFLY_INSET:8.5039"
        //            + "-SIDE_CENTER_MARKS:NO"
        //            + "-PUNCHMARK:NO"
        //            + "-SMARTCOLLATION_STEPFROMOFFSETORIGIN:NO"
        //            + "-LAYERING:NO"
        //            + "-O:F"
        //            + "-OUTPUTONLYFORHOTFOLDER:3"
        //            + "-STRIPPINGPLACEHOLDERS:NO"
        //            + "-ADOBEPJTF:YES"
        //            + "-JDFOUTPUT:NO"
        //            + "-WSTOUTPUT:NO"
        //            + "-EXPORTPDF:NO"
        //            + "-BRISQUE_PS:NO"
        //            + "-USE_PPT_PDFLIB:NO"
        //            + "-JDFResolveCheckSheetSize:NO"
        //            + "-JDFResolveCheckWorkstyle:NO"
        //            + "-JDFResolveCheckHeadFootTrim:NO"
        //            + "-JDFResolveCheckFoldingPattern:NO"
        //            + "-JDFOutputToTargetRoute:NO"
        //            + "-JDFResolveCheckFoldingOrientation:NO"
        //            + "-JDFResolveGenerateMissingSignatures:NO"
        //            + "-JDFOutputLAYCRIMP13:NO"
        //            + "-JDFOutputRelativeMarkPaths:NO"
        //            + "-JDFOutputRelativeContentPaths:NO"
        //            + "-JDFResolveStrictStatus:YES"
        //            + "-JDFNoResolveCreateOnly:NO"
        //            + "-DEFAULT_ADD_SHEET_MARKS:YES"
        //            + "-JDFAddErrorMarks:YES"
        //            + "-JDFErrorMarkTolerance:0.0050"
        //            + "-JDFResolveEqualityTolerance:0.0050"
        //            + "-SIDEGUIDEANCHOR:1"
        //            + "-PJTF_ENABLE_SOURCE_CLIP_PATH:YES"
        //            + "-PJTF_COMPRESS_STREAMS:YES"
        //            + "-PJTF_SSIDOS_ENCODING_IS_UCS2:NO"
        //            + "-OPI:MISSING"
        //            + "-OPIMERGEDTHRESHOLD:1000"
        //            + "-OUTSPLIT:NONE"
        //            + "-ShingleCropMarks:YES"
        //            + "-ShingleScalingProportional:NO"
        //            + "-PPD43:NO"
        //            + "-PRINTER:PressSheet"
        //            + "-PSMARGIN:0.0000"
        //            + "-REDUCE:NO"
        //            + "-MISFONTDOWNLOAD:YES"
        //            + "-MISFONTPRIORITY1:2"
        //            + "-MISFONTPRIORITY2:1"
        //            + "-MISFONTPRIORITY3:3"
        //            + "-MISFONTPRIORITY4:4"
        //            + "-MISFONTPRIORITY1ENABLED:YES"
        //            + "-MISFONTPRIORITY2ENABLED:YES"
        //            + "-MISFONTPRIORITY3ENABLED:YES"
        //            + "-MISFONTPRIORITY4ENABLED:YES"
        //            + "-MISFONTREPORTALL:YES"
        //            + "-SEPS:NO"
        //            + "-SEPSRIP:NO"
        //            + "-SPLITERROR:NO"
        //            + "-SPOT2CMYK:NO"
        //            + "-SSCFILTER:YES"
        //            + "-SSCLIMIT:50"
        //            + "-SSCPASSSPOT:NO"
        //            + "-TOTALLIMIT:300.0000"
        //            + "-UCRAMOUNT:0.0000"
        //            + "-WEBGROWTHDO:NO"
        //            + "-WGSCALEENTITIES:NO"
        //            + "-WHITEKOCMYK:NO"
        //            + "-WHITEOPCMYK:NO"
        //            + "-WHITEKOSPOT:NO"
        //            + "-WHITEOPSPOT:NO"
        //            + "-GCR:NO"
        //            + "-GCRTYPE:0"
        //            + "-FORCETOPUNCH:YES"
        //            + "-ADDTILEMARKS:YES"
        //            + "-ALLOWSPLIT:NO"
        //            + "-BACKMIRRORFRONT:NO"
        //            + "-IMAGEOVERLAP:CENTER"
        //            + "-NOPUNCHDIST:72.0000"
        //            + "-PINDIST:144.0000"
        //            + "-PADPAGES:NO"
        //            + "-VTILEMARGIN:9.0000"
        //            + "-VTILEGRACE:0.0000"
        //            + "-TILEMARGIN:36.0000"
        //            + "-TRAPPING:YES"
        //            + "-TILEMODE:3"
        //            + "-DEFAULT_JOB_KIND:2"
        //            + "-WINDOW_SIZE_FILE_LIST:0 0 200 800 1 "
        //            + "-WINDOW_SIZE_RUN_LIST:230 0 200 800 2 "
        //            + "-WINDOW_SIZE_SIGNATURE_LIST:460 0 200 800 3 "
        //            + "-TILEOVERLAP:36.0000"
        //            + "-TILETOFIT:NO"
        //            + "-UNITS:3"
        //            + "-PRECISION:NO"
        //            + "-ADJUSTPRECISION:0.2000"
        //            + "-METRIC_PAGE_WIDTH:595.2756"
        //            + "-METRIC_PAGE_HEIGHT:841.8897"
        //            + "-METRIC_PRESS_SHEET_WIDTH:2834.6457"
        //            + "-METRIC_PRESS_SHEET_HEIGHT:1984.2520"
        //            + "-METRIC_SIDE_GUIDE_DISTANCE:283.4646"
        //            + "-METRIC_CENTER_MARK_LENGTH:17.0080"
        //            + "-METRIC_BLEED_MARGIN:8.5040"
        //            + "-METRIC_MARK_WIDTH:17.0080"
        //            + "-METRIC_MARK_HEIGHT:17.0080"
        //            + "-METRIC_CROP_MARK_DISTANCE:8.5040"
        //            + "-METRIC_CROP_MARK_LENGTH:19.8426"
        //            + "-METRIC_LINE_WIDTH:0.1700"
        //            + "-METRIC_FOLD_MARK_LENGTH:17.0080"
        //            + "-METRIC_PRESS_SHEET_EDGE_TO_PUNCH_CENTER:141.7323"
        //            + "-METRIC_MEDIA_SIZE:A4"
        //            + "-AMERICAN_PAGE_WIDTH:612.0000"
        //            + "-AMERICAN_PAGE_HEIGHT:792.0000"
        //            + "-AMERICAN_PRESS_SHEET_WIDTH:2736.0000"
        //            + "-AMERICAN_PRESS_SHEET_HEIGHT:1800.0000"
        //            + "-AMERICAN_SIDE_GUIDE_DISTANCE:288.0000"
        //            + "-AMERICAN_CENTER_MARK_LENGTH:36.0000"
        //            + "-AMERICAN_BLEED_MARGIN:9.0000"
        //            + "-AMERICAN_MARK_WIDTH:18.0000"
        //            + "-AMERICAN_MARK_HEIGHT:18.0000"
        //            + "-AMERICAN_CROP_MARK_DISTANCE:9.0000"
        //            + "-AMERICAN_CROP_MARK_LENGTH:18.0000"
        //            + "-AMERICAN_LINE_WIDTH:0.2500"
        //            + "-AMERICAN_FOLD_MARK_LENGTH:36.0000"
        //            + "-AMERICAN_PRESS_SHEET_EDGE_TO_PUNCH_CENTER:108.0000"
        //            + "-AMERICAN_MEDIA_SIZE:Letter"
        //            + "-WAITFORSYNC:300"
        //            + "-WAITFORINFO:10"
        //            + "-TEXTMARKFONT:Helvetica"
        //            + "-TEXTMARKENCODING:0"
        //            + "-ROMAN_TEXTMARKFONT:Helvetica"
        //            + "-ROMAN_TEXTMARKENCODING:0"
        //            + "-CJK_TEXTMARKFONTNAME:ShanHeiSun-Uni"
        //            + "-CJK_TEXTMARKFONTNAMEPREVIEW:ShanHeiSun-Uni"
        //            + "-CJK_TEXTMARKCHARACTERCOLLECTION:Adobe-GB1-4"
        //            + "-CJK_TEXTMARKFONTENCODINGSTRING:UniGB-UCS2"
        //            + "-CJK_TEXTMARKENCODING:256"
        //            + "-ADDTORUNLIST:YES"
        //            + "-SPLITFILENAME:{PrintID<19>}{Sig<3>}{Side<2>}{XTile<1>}{YTile<1>}[.ps]"
        //            + "-PDFSPLITFILENAME:{PrintID<21>}{Sig<3>}{Side<2>}[.pdf]"
        //            + "-MARKTEMPLATEPARENTPATH:\\\\evo28204\\Preps\\"
        //            + "-PRINTERSPATH:C:\\Preps 5.3.2\\Printers\\"
        //            + "-KEEPEXCHANGERUNNING:YES"
        //            + "-ACROBATEXCHANGEPATH:C:\\Program Files (x86)\\Adobe\\Acrobat 8.0\\Acrobat\\Acrobat.exe"
        //            + "-USEACROBATTOCONVERT:NO"
        //            + "-PDFLIBBINARYDATA:NO"
        //            + "-PDFLIBINCLUDEFONTS:"
        //            + "-PDFRENDERFLAGS:SmoothText, SmoothLineArt, SmoothImage, OverPrint"
        //            + "-PDFPREVIEWVIAPS:NO"
        //            + "-PLUGINBINARYDATA:YES"
        //            + "-PLUGINPSLEVEL:3"
        //            + "-DELETEPSFROMPDF:NO"
        //            + "-INTERNALCONVERTERTIMEOUT:600"
        //            + "-SEPL1_COMP:2"
        //            + "-SEPL1_PRESEP:1"
        //            + "-SEPL2_COMP:2"
        //            + "-SEPL2_PRESEP:2"
        //            + "-VERSION:3"
        //            + "-DATEMACRO:$date"
        //            + "-RIPTIMEOUT:120"
        //            + "-HANDLE_DCS_SEGMENT_LIKE_PREPS41:YES"
        //            + "-INCLUDE_DCS_EPSF_AFTER_ENDCOMMENTS:NO"
        //            + "-DEFAULTBINDINGSTYLE:2"
        //            + "-ADD_WHITE_KO_UNDER_CROP_MARK:YES"
        //            + "-ADD_WHITE_KO_UNDER_FOLD_MARK:YES"
        //            + "-AUTOSELECT_MINIMUM_PAGES:1"
        //            + "-DIVIDEBYVALUE:0000000"
        //            + "-DIVIDEBYCOMBOBOXVALUE:0000000"
        //            + "-COLLATEDVALUE:0000000"
        //            + "-DOUBLESIDEVALUE:0000000"
        //            + "-GENERATECIP3VALUE:0000000"
        //            + "-CSSELECTIONVALUE:0000000"
        //            + "-OVERRIDELINESCREENVALUE:0000100"
        //            + "-OVERRIDESPOTSHAPEVALUE:0000000"
        //            + "-TEMPLATE_TOOL_XLOCATION:6"
        //            + "-TEMPLATE_TOOL_YLOCATION:80";

        //    //写入文件
        //    File.WriteAllText(defaultFile, defaultText);


        //    return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }

        //}
    }
}
