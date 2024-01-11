Public Enum AtomType
  XA_PRIMARY = 1
  XA_SECONDARY = 2
  XA_ARC = 3
  XA_ATOM = 4
  XA_BITMAP = 5
  XA_CARDINAL = 6
  XA_COLORMAP = 7
  XA_CURSOR = 8
  XA_CUT_BUFFER0 = 9
  XA_CUT_BUFFER1 = 10
  XA_CUT_BUFFER2 = 11
  XA_CUT_BUFFER3 = 12
  XA_CUT_BUFFER4 = 13
  XA_CUT_BUFFER5 = 14
  XA_CUT_BUFFER6 = 15
  XA_CUT_BUFFER7 = 16
  XA_DRAWABLE = 17
  XA_FONT = 18
  XA_INTEGER = 19
  XA_PIXMAP = 20
  XA_POINT = 21
  XA_RECTANGLE = 22
  XA_RESOURCE_MANAGER = 23
  XA_RGB_COLOR_MAP = 24
  XA_RGB_BEST_MAP = 25
  XA_RGB_BLUE_MAP = 26
  XA_RGB_DEFAULT_MAP = 27
  XA_RGB_GRAY_MAP = 28
  XA_RGB_GREEN_MAP = 29
  XA_RGB_RED_MAP = 30
  XA_STRING = 31
  XA_VISUALID = 32
  XA_WINDOW = 33
  XA_WM_COMMAND = 34
  XA_WM_HINTS = 35
  XA_WM_CLIENT_MACHINE = 36
  XA_WM_ICON_NAME = 37
  XA_WM_ICON_SIZE = 38
  XA_WM_NAME = 39
  XA_WM_NORMAL_HINTS = 40
  XA_WM_SIZE_HINTS = 41
  XA_WM_ZOOM_HINTS = 42
  XA_MIN_SPACE = 43
  XA_NORM_SPACE = 44
  XA_MAX_SPACE = 45
  XA_END_SPACE = 46
  XA_SUPERSCRIPT_X = 47
  XA_SUPERSCRIPT_Y = 48
  XA_SUBSCRIPT_X = 49
  XA_SUBSCRIPT_Y = 50
  XA_UNDERLINE_POSITION = 51
  XA_UNDERLINE_THICKNESS = 52
  XA_STRIKEOUT_ASCENT = 53
  XA_STRIKEOUT_DESCENT = 54
  XA_ITALIC_ANGLE = 55
  XA_X_HEIGHT = 56
  XA_QUAD_WIDTH = 57
  XA_WEIGHT = 58
  XA_POINT_SIZE = 59
  XA_RESOLUTION = 60
  XA_COPYRIGHT = 61
  XA_NOTICE = 62
  XA_FONT_NAME = 63
  XA_FAMILY_NAME = 64
  XA_FULL_NAME = 65
  XA_CAP_HEIGHT = 66
  XA_WM_CLASS = 67
  XA_WM_TRANSIENT_FOR = 68
End Enum

Public Enum Gravity
  ' Bit Gravity 
  ForgetGravity = 0
  NorthWestGravity = 1
  NorthGravity = 2
  NorthEastGravity = 3
  WestGravity = 4
  CenterGravity = 5
  EastGravity = 6
  SouthWestGravity = 7
  SouthGravity = 8
  SouthEastGravity = 9
  StaticGravity = 10
  ''' * Window gravity + bit gravity above */
  'UnmapGravity    0 
End Enum

Public Enum PropMode
  PropModeReplace = 0
  PropModePrepend = 1
  PropModeAppend = 2
End Enum

<Flags()>
Public Enum XConfigureWindowMask
  CWX = (1 << 0)
  CWY = (1 << 1)
  CWWidth = (1 << 2)
  CWHeight = (1 << 3)
  CWBorderWidth = (1 << 4)
  CWSibling = (1 << 5)
  CWStackMode = (1 << 6)
End Enum

Public Enum XCursors
  XC_num_glyphs = 154
  XC_X_cursor = 0
  XC_arrow = 2
  XC_based_arrow_down = 4
  XC_based_arrow_up = 6
  XC_boat = 8
  XC_bogosity = 10
  XC_bottom_left_corner = 12
  XC_bottom_right_corner = 14
  XC_bottom_side = 16
  XC_bottom_tee = 18
  XC_box_spiral = 20
  XC_center_ptr = 22
  XC_circle = 24
  XC_clock = 26
  XC_coffee_mug = 28
  XC_cross = 30
  XC_cross_reverse = 32
  XC_crosshair = 34
  XC_diamond_cross = 36
  XC_dot = 38
  XC_dotbox = 40
  XC_double_arrow = 42
  XC_draft_large = 44
  XC_draft_small = 46
  XC_draped_box = 48
  XC_exchange = 50
  XC_fleur = 52
  XC_gobbler = 54
  XC_gumby = 56
  XC_hand1 = 58
  XC_hand2 = 60
  XC_heart = 62
  XC_icon = 64
  XC_iron_cross = 66
  XC_left_ptr = 68
  XC_left_side = 70
  XC_left_tee = 72
  XC_leftbutton = 74
  XC_ll_angle = 76
  XC_lr_angle = 78
  XC_man = 80
  XC_middlebutton = 82
  XC_mouse = 84
  XC_pencil = 86
  XC_pirate = 88
  XC_plus = 90
  XC_question_arrow = 92
  XC_right_ptr = 94
  XC_right_side = 96
  XC_right_tee = 98
  XC_rightbutton = 100
  XC_rtl_logo = 102
  XC_sailboat = 104
  XC_sb_down_arrow = 106
  XC_sb_h_double_arrow = 108
  XC_sb_left_arrow = 110
  XC_sb_right_arrow = 112
  XC_sb_up_arrow = 114
  XC_sb_v_double_arrow = 116
  XC_shuttle = 118
  XC_sizing = 120
  XC_spider = 122
  XC_spraycan = 124
  XC_star = 126
  XC_target = 128
  XC_tcross = 130
  XC_top_left_arrow = 132
  XC_top_left_corner = 134
  XC_top_right_corner = 136
  XC_top_side = 138
  XC_top_tee = 140
  XC_trek = 142
  XC_ul_angle = 144
  XC_umbrella = 146
  XC_ur_angle = 148
  XC_watch = 150
  XC_xterm = 152
End Enum

Public Enum XEventMode
  AsyncPointer = 0
  SyncPointer = 1
  ReplayPointer = 2
  AsyncKeyboard = 3
  SyncKeyboard = 4
  ReplayKeyboard = 5
  AsyncBoth = 6
  SyncBoth = 7
End Enum

Public Enum XErrorCode
  Success = 0
  BadRequest = 1
  BadValue = 2
  BadWindow = 3
  BadPixmap = 4
  BadAtom = 5
  BadCursor = 6
  BadFont = 7
  BadMatch = 8
  BadDrawable = 9
  BadAccess = 10
  BadAlloc = 11
  BadColor = 12
  BadGC = 13
  BadIDChoice = 14
  BadName = 15
  BadLength = 16
  BadImplementation = 17
End Enum

<Flags()>
Public Enum XEventMask
  KeyPressMask = (1 << 0)
  KeyReleaseMask = (1 << 1)
  ButtonPressMask = (1 << 2)
  ButtonReleaseMask = (1 << 3)
  EnterWindowMask = (1 << 4)
  LeaveWindowMask = (1 << 5)
  PointerMotionMask = (1 << 6)
  PointerMotionHintMask = (1 << 7)
  Button1MotionMask = (1 << 8)
  Button2MotionMask = (1 << 9)
  Button3MotionMask = (1 << 10)
  Button4MotionMask = (1 << 11)
  Button5MotionMask = (1 << 12)
  ButtonMotionMask = (1 << 13)
  KeymapStateMask = (1 << 14)
  ExposureMask = (1 << 15)
  VisibilityChangeMask = (1 << 16)
  StructureNotifyMask = (1 << 17)
  ResizeRedirectMask = (1 << 18)
  SubstructureNotifyMask = (1 << 19)
  SubstructureRedirectMask = (1 << 20)
  FocusChangeMask = (1 << 21)
  PropertyChangeMask = (1 << 22)
  ColormapChangeMask = (1 << 23)
End Enum

<Flags()>
Public Enum XEventType
  KeyPress = 2
  KeyRelease = 3
  ButtonPress = 4
  ButtonRelease = 5
  MotionNotify = 6
  EnterNotify = 7
  LeaveNotify = 8
  FocusIn = 9
  FocusOut = 10
  KeymapNotify = 11
  Expose = 12
  GraphicsExpose = 13
  NoExpose = 14
  VisibilityNotify = 15
  CreateNotify = 16
  DestroyNotify = 17
  UnmapNotify = 18
  MapNotify = 19
  MapRequest = 20
  ReparentNotify = 21
  ConfigureNotify = 22
  ConfigureRequest = 23
  GravityNotify = 24
  ResizeRequest = 25
  CirculateNotify = 26
  CirculateRequest = 27
  PropertyNotify = 28
  SelectionClear = 29
  SelectionRequest = 30
  SelectionNotify = 31
  ColormapNotify = 32
  ClientMessage = 33
  MappingNotify = 34
End Enum

<Flags()>
Public Enum XGCFunctionMask
  GXclear = &H0
  GXand = &H1
  GXandReverse = &H2
  GXcopy = &H3
  GXandInverted = &H4
  GXnoop = &H5
  GXxor = &H6
  GXor = &H7
  GXnor = &H8
  GXequiv = &H9
  GXinvert = &HA
  GXorReverse = &HB
  GXcopyInverted = &HC
  GXorInverted = &HD
  GXnand = &HE
  GXset = &HF
End Enum

<Flags()>
Public Enum XGCValuesMask
  GCFunction = (1 << 0)
  GCPlaneMask = (1 << 1)
  GCForeground = (1 << 2)
  GCBackground = (1 << 3)
  GCLineWidth = (1 << 4)
  GCLineStyle = (1 << 5)
  GCCapStyle = (1 << 6)
  GCJoinStyle = (1 << 7)
  GCFillStyle = (1 << 8)
  GCFillRule = (1 << 9)
  GCTile = (1 << 10)
  GCStipple = (1 << 11)
  GCTileStipXOrigin = (1 << 12)
  GCTileStipYOrigin = (1 << 13)
  GCFont = (1 << 14)
  GCSubwindowMode = (1 << 15)
  GCGraphicsExposures = (1 << 16)
  GCClipXOrigin = (1 << 17)
  GCClipYOrigin = (1 << 18)
  GCClipMask = (1 << 19)
  GCDashOffset = (1 << 20)
  GCDashList = (1 << 21)
  GCArcMode = (1 << 22)
End Enum

Public Enum XGrabMode
  GrabModeSync = 0
  GrabModeAsync = 1
End Enum

Public Enum XInputFocus
  RevertToNone = 0
  RevertToPointerRoot = 1
  RevertToParent = 2
End Enum

Public Enum XKeySym

  NoSymbol = 0

  ' * TTY function keys, cleverly chosen to map to ASCII, for convenience of
  ' * programming, but could have been arbitrary (at the cost of lookup
  ' * tables in client code).

  ''' <summary>
  ''' Back space, back char 
  ''' </summary>
  XK_BackSpace = &HFF08
  XK_Tab = &HFF09
  ''' <summary>
  ''' Linefeed, LF
  ''' </summary>
  XK_Linefeed = &HFF0A
  XK_Clear = &HFF0B
  ''' <summary>
  ''' Return, enter
  ''' </summary>
  XK_Return = &HFF0D
  ''' <summary>
  ''' Pause, hold 
  ''' </summary>
  XK_Pause = &HFF13
  XK_Scroll_Lock = &HFF14
  XK_Sys_Req = &HFF15
  XK_Escape = &HFF1B
  ''' <summary>
  ''' Delete, rubout
  ''' </summary>
  XK_Delete = &HFFFF

  ' * International & multi-key character composition

  ' * Japanese keyboard support

  ' * 0xff31 thru 0xff3f are under XK_KOREAN

  ' * Cursor control & motion

  XK_Home = &HFF50
  ''' <summary>
  ''' Move left, left arrow
  ''' </summary>
  XK_Left = &HFF51
  ''' <summary>
  ''' Move up, up arrow
  ''' </summary>
  XK_Up = &HFF52
  ''' <summary>
  ''' Move right, right arrow
  ''' </summary>
  XK_Right = &HFF53
  ''' <summary>
  ''' Move down, down arrow
  ''' </summary>
  XK_Down = &HFF54
  ''' <summary>
  ''' Prior, previous
  ''' </summary>
  XK_Page_Up = &HFF55
  'XK_Prior = &HFF55
  ''' <summary>
  ''' Next
  ''' </summary>
  XK_Page_Down = &HFF56
  'XK_Next = &HFF56
  ''' <summary>
  ''' EOL
  ''' </summary>
  XK_End = &HFF57
  ''' <summary>
  ''' BOL
  ''' </summary>
  XK_Begin = &HFF58

  ' * Misc functions

  ' * Keypad functions, keypad numbers cleverly chosen to map to ASCII

  ''' <summary>
  ''' Space
  ''' </summary>
  XK_KP_Space = &HFF80
  XK_KP_Tab = &HFF89
  ''' <summary>
  ''' Enter
  ''' </summary>
  XK_KP_Enter = &HFF8D
  ''' <summary>
  ''' PF1, KP_A, ...
  ''' </summary>
  XK_KP_F1 = &HFF91
  XK_KP_F2 = &HFF92
  XK_KP_F3 = &HFF93
  XK_KP_F4 = &HFF94
  XK_KP_Home = &HFF95
  XK_KP_Left = &HFF96
  XK_KP_Up = &HFF97
  XK_KP_Right = &HFF98
  XK_KP_Down = &HFF99
  'XK_KP_Prior = &HFF9A
  XK_KP_Page_Up = &HFF9A
  'XK_KP_Next = &HFF9B
  XK_KP_Page_Down = &HFF9B
  XK_KP_End = &HFF9C
  XK_KP_Begin = &HFF9D
  XK_KP_Insert = &HFF9E
  XK_KP_Delete = &HFF9F
  ''' <summary>
  ''' Equals
  ''' </summary>
  XK_KP_Equal = &HFFBD
  XK_KP_Multiply = &HFFAA
  XK_KP_Add = &HFFAB
  ''' <summary>
  ''' Separator, often comma
  ''' </summary>
  XK_KP_Separator = &HFFAC
  XK_KP_Subtract = &HFFAD
  XK_KP_Decimal = &HFFAE
  XK_KP_Divide = &HFFAF

  XK_KP_0 = &HFFB0
  XK_KP_1 = &HFFB1
  XK_KP_2 = &HFFB2
  XK_KP_3 = &HFFB3
  XK_KP_4 = &HFFB4
  XK_KP_5 = &HFFB5
  XK_KP_6 = &HFFB6
  XK_KP_7 = &HFFB7
  XK_KP_8 = &HFFB8
  XK_KP_9 = &HFFB9

  ' * Auxiliary functions; note the duplicate definitions for left and right
  ' * function keys;  Sun keyboards And a few other manufacturers have such
  ' * function key groups on the left And/Or right sides of the keyboard.
  ' * We've not found a keyboard with more than 35 function keys total.

  XK_F1 = &HFFBE
  XK_F2 = &HFFBF
  XK_F3 = &HFFC0
  XK_F4 = &HFFC1
  XK_F5 = &HFFC2
  XK_F6 = &HFFC3
  XK_F7 = &HFFC4
  XK_F8 = &HFFC5
  XK_F9 = &HFFC6
  XK_F10 = &HFFC7
  XK_F11 = &HFFC8
  'XK_L1 = &HFFC8
  XK_F12 = &HFFC9
  'XK_L2 = &HFFC9
  XK_F13 = &HFFCA
  'XK_L3 = &HFFCA
  XK_F14 = &HFFCB
  'XK_L4 = &HFFCB
  XK_F15 = &HFFCC
  'XK_L5 = &HFFCC
  XK_F16 = &HFFCD
  'XK_L6 = &HFFCD
  XK_F17 = &HFFCE
  'XK_L7 = &HFFCE
  XK_F18 = &HFFCF
  'XK_L8 = &HFFCF
  XK_F19 = &HFFD0
  'XK_L9 = &HFFD0
  XK_F20 = &HFFD1
  'XK_L10 = &HFFD1
  XK_F21 = &HFFD2
  'XK_R1 = &HFFD2
  XK_F22 = &HFFD3
  'XK_R2 = &HFFD3
  XK_F23 = &HFFD4
  'XK_R3 = &HFFD4
  XK_F24 = &HFFD5
  'XK_R4 = &HFFD5
  XK_F25 = &HFFD6
  'XK_R5 = &HFFD6
  XK_F26 = &HFFD7
  'XK_R6 = &HFFD7
  XK_F27 = &HFFD8
  'XK_R7 = &HFFD8
  XK_F28 = &HFFD9
  'XK_R8 = &HFFD9
  XK_F29 = &HFFDA
  'XK_R9 = &HFFDA
  XK_F30 = &HFFDB
  'XK_R10 = &HFFDB
  XK_F31 = &HFFDC
  'XK_R11 = &HFFDC
  XK_F32 = &HFFDD
  'XK_R12 = &HFFDD
  XK_F33 = &HFFDE
  'XK_R13 = &HFFDE
  XK_F34 = &HFFDF
  'XK_R14 = &HFFDF
  XK_F35 = &HFFE0
  'XK_R15 = &HFFE0

  ' * Modifiers

  ''' <summary>
  ''' Left shift
  ''' </summary>
  XK_Shift_L = &HFFE1
  ''' <summary>
  ''' Right shift
  ''' </summary>
  XK_Shift_R = &HFFE2
  ''' <summary>
  ''' Left control
  ''' </summary>
  XK_Control_L = &HFFE3
  ''' <summary>
  ''' Right control
  ''' </summary>
  XK_Control_R = &HFFE4
  ''' <summary>
  ''' Caps lock
  ''' </summary>
  XK_Caps_Lock = &HFFE5
  ''' <summary>
  ''' Shift lock
  ''' </summary>
  XK_Shift_Lock = &HFFE6
  ''' <summary>
  ''' Left meta
  ''' </summary>
  XK_Meta_L = &HFFE7
  ''' <summary>
  ''' Right meta
  ''' </summary>
  XK_Meta_R = &HFFE8
  ''' <summary>
  ''' Left alt
  ''' </summary>
  XK_Alt_L = &HFFE9
  ''' <summary>
  ''' Right alt
  ''' </summary>
  XK_Alt_R = &HFFEA
  ''' <summary>
  ''' Left super
  ''' </summary>
  XK_Super_L = &HFFEB
  ''' <summary>
  ''' Right super
  ''' </summary>
  XK_Super_R = &HFFEC
  ''' <summary>
  ''' Left hyper
  ''' </summary>
  XK_Hyper_L = &HFFED
  ''' <summary>
  ''' Right hyper
  ''' </summary>
  XK_Hyper_R = &HFFEE

  ' * Latin 1
  ' * (ISO/IEC 8859-1 = Unicode U+0020..U+00FF)
  ' * Byte 3 = 0

  ''' <summary>
  ''' U+0020 SPACE
  ''' </summary>
  XK_space = &H20
  ''' <summary>
  ''' U+0021 EXCLAMATION MARK 
  ''' </summary>
  XK_exclam = &H21
  ''' <summary>
  ''' U+0022 QUOTATION MARK
  ''' </summary>
  XK_quotedbl = &H22
  ''' <summary>
  ''' U+0023 NUMBER SIGN
  ''' </summary>
  XK_numbersign = &H23
  ''' <summary>
  ''' U+0024 DOLLAR SIGN
  ''' </summary>
  XK_dollar = &H24
  ''' <summary>
  ''' U+0025 PERCENT SIGN
  ''' </summary>
  XK_percent = &H25
  ''' <summary>
  ''' U+0026 AMPERSAND
  ''' </summary>
  XK_ampersand = &H26
  ''' <summary>
  ''' U+0027 APOSTROPHE
  ''' </summary>
  XK_apostrophe = &H27
  '''' <summary>
  '''' deprecated
  '''' </summary>
  'XK_quoteright = &H27
  ''' <summary>
  ''' U+0028 LEFT PARENTHESIS
  ''' </summary>
  XK_parenleft = &H28
  ''' <summary>
  ''' U+0029 RIGHT PARENTHESIS
  ''' </summary>
  XK_parenright = &H29
  ''' <summary>
  ''' U+002A ASTERISK
  ''' </summary>
  XK_asterisk = &H2A
  ''' <summary>
  ''' U+002B PLUS SIGN
  ''' </summary>
  XK_plus = &H2B
  ''' <summary>
  ''' U+002C COMMA
  ''' </summary>
  XK_comma = &H2C
  ''' <summary>
  ''' U+002D HYPHEN-MINUS
  ''' </summary>
  XK_minus = &H2D
  ''' <summary>
  ''' U+002E FULL STOP
  ''' </summary>
  XK_period = &H2E
  ''' <summary>
  ''' U+002F SOLIDUS
  ''' </summary>
  XK_slash = &H2F
  ''' <summary>
  ''' U+0030 DIGIT ZERO
  ''' </summary>
  XK_0 = &H30
  ''' <summary>
  ''' U+0031 DIGIT ONE
  ''' </summary>
  XK_1 = &H31
  ''' <summary>
  ''' U+0032 DIGIT TWO
  ''' </summary>
  XK_2 = &H32
  ''' <summary>
  ''' U+0033 DIGIT THREE
  ''' </summary>
  XK_3 = &H33
  ''' <summary>
  ''' U+0034 DIGIT FOUR
  ''' </summary>
  XK_4 = &H34
  ''' <summary>
  ''' U+0035 DIGIT FIVE
  ''' </summary>
  XK_5 = &H35
  ''' <summary>
  ''' U+0036 DIGIT SIX
  ''' </summary>
  XK_6 = &H36
  ''' <summary>
  ''' U+0037 DIGIT SEVEN
  ''' </summary>
  XK_7 = &H37
  ''' <summary>
  ''' U+0038 DIGIT EIGHT
  ''' </summary>
  XK_8 = &H38
  ''' <summary>
  ''' U+0039 DIGIT NINE
  ''' </summary>
  XK_9 = &H39
  ''' <summary>
  ''' U+003A COLON
  ''' </summary>
  XK_colon = &H3A
  ''' <summary>
  ''' U+003B SEMICOLON
  ''' </summary>
  XK_semicolon = &H3B
  ''' <summary>
  ''' U+003C LESS-THAN SIGN
  ''' </summary>
  XK_less = &H3C
  ''' <summary>
  ''' U+003D EQUALS SIGN
  ''' </summary>
  XK_equal = &H3D
  ''' <summary>
  ''' U+003E GREATER-THAN SIGN
  ''' </summary>
  XK_greater = &H3E
  ''' <summary>
  ''' U+003F QUESTION MARK
  ''' </summary>
  XK_question = &H3F
  ''' <summary>
  ''' U+0040 COMMERCIAL AT
  ''' </summary>
  XK_at = &H40
  ''' <summary>
  ''' U+0041 LATIN CAPITAL LETTER A
  ''' </summary>
  XK_c_A = &H41
  ''' <summary>
  ''' U+0042 LATIN CAPITAL LETTER B
  ''' </summary>
  XK_c_B = &H42
  ''' <summary>
  ''' U+0043 LATIN CAPITAL LETTER C
  ''' </summary>
  XK_c_C = &H43
  ''' <summary>
  ''' U+0044 LATIN CAPITAL LETTER D
  ''' </summary>
  XK_c_D = &H44
  ''' <summary>
  ''' U+0045 LATIN CAPITAL LETTER E
  ''' </summary>
  XK_c_E = &H45
  ''' <summary>
  ''' U+0046 LATIN CAPITAL LETTER F
  ''' </summary>
  XK_c_F = &H46
  ''' <summary>
  ''' U+0047 LATIN CAPITAL LETTER G
  ''' </summary>
  XK_c_G = &H47
  ''' <summary>
  ''' U+0048 LATIN CAPITAL LETTER H
  ''' </summary>
  XK_c_H = &H48
  ''' <summary>
  ''' U+0049 LATIN CAPITAL LETTER I
  ''' </summary>
  XK_c_I = &H49
  ''' <summary>
  ''' U+004A LATIN CAPITAL LETTER J
  ''' </summary>
  XK_c_J = &H4A
  ''' <summary>
  ''' U+004B LATIN CAPITAL LETTER K
  ''' </summary>
  XK_c_K = &H4B
  ''' <summary>
  ''' U+004C LATIN CAPITAL LETTER L
  ''' </summary>
  XK_c_L = &H4C
  ''' <summary>
  ''' U+004D LATIN CAPITAL LETTER M
  ''' </summary>
  XK_c_M = &H4D
  ''' <summary>
  ''' U+004E LATIN CAPITAL LETTER N
  ''' </summary>
  XK_c_N = &H4E
  ''' <summary>
  ''' U+004F LATIN CAPITAL LETTER O
  ''' </summary>
  XK_c_O = &H4F
  ''' <summary>
  ''' U+0050 LATIN CAPITAL LETTER P
  ''' </summary>
  XK_c_P = &H50
  ''' <summary>
  ''' U+0051 LATIN CAPITAL LETTER Q
  ''' </summary>
  XK_c_Q = &H51
  ''' <summary>
  ''' U+0052 LATIN CAPITAL LETTER R
  ''' </summary>
  XK_c_R = &H52
  ''' <summary>
  ''' U+0053 LATIN CAPITAL LETTER S
  ''' </summary>
  XK_c_S = &H53
  ''' <summary>
  ''' U+0054 LATIN CAPITAL LETTER T
  ''' </summary>
  XK_c_T = &H54
  ''' <summary>
  ''' U+0055 LATIN CAPITAL LETTER U
  ''' </summary>
  XK_c_U = &H55
  ''' <summary>
  ''' U+0056 LATIN CAPITAL LETTER V
  ''' </summary>
  XK_c_V = &H56
  ''' <summary>
  ''' U+0057 LATIN CAPITAL LETTER W
  ''' </summary>
  XK_c_W = &H57
  ''' <summary>
  ''' U+0058 LATIN CAPITAL LETTER X
  ''' </summary>
  XK_c_X = &H58
  ''' <summary>
  ''' U+0059 LATIN CAPITAL LETTER Y
  ''' </summary>
  XK_c_Y = &H59
  ''' <summary>
  ''' U+005A LATIN CAPITAL LETTER Z
  ''' </summary>
  XK_c_Z = &H5A
  ''' <summary>
  ''' U+005B LEFT SQUARE BRACKET
  ''' </summary>
  XK_bracketleft = &H5B
  ''' <summary>
  ''' U+005C REVERSE SOLIDUS
  ''' </summary>
  XK_backslash = &H5C
  ''' <summary>
  ''' U+005D RIGHT SQUARE BRACKET
  ''' </summary>
  XK_bracketright = &H5D
  ''' <summary>
  ''' U+005E CIRCUMFLEX ACCENT
  ''' </summary>
  XK_asciicircum = &H5E
  ''' <summary>
  ''' U+005F LOW LINE
  ''' </summary>
  XK_underscore = &H5F
  ''' <summary>
  ''' U+0060 GRAVE ACCENT
  ''' </summary>
  XK_grave = &H60
  '''' <summary>
  '''' deprecated
  '''' </summary>
  'XK_quoteleft = &H60
  ''' <summary>
  ''' U+0061 LATIN SMALL LETTER A
  ''' </summary>
  XK_a = &H61
  ''' <summary>
  ''' U+0062 LATIN SMALL LETTER B
  ''' </summary>
  XK_b = &H62
  ''' <summary>
  ''' U+0063 LATIN SMALL LETTER C
  ''' </summary>
  XK_c = &H63
  ''' <summary>
  ''' U+0064 LATIN SMALL LETTER D
  ''' </summary>
  XK_d = &H64
  ''' <summary>
  ''' U+0065 LATIN SMALL LETTER E
  ''' </summary>
  XK_e = &H65
  ''' <summary>
  ''' U+0066 LATIN SMALL LETTER F
  ''' </summary>
  XK_f = &H66
  ''' <summary>
  ''' U+0067 LATIN SMALL LETTER G
  ''' </summary>
  XK_g = &H67
  ''' <summary>
  ''' U+0068 LATIN SMALL LETTER H
  ''' </summary>
  XK_h = &H68
  ''' <summary>
  ''' U+0069 LATIN SMALL LETTER I
  ''' </summary>
  XK_i = &H69
  ''' <summary>
  ''' U+006A LATIN SMALL LETTER J
  ''' </summary>
  XK_j = &H6A
  ''' <summary>
  ''' U+006B LATIN SMALL LETTER K
  ''' </summary>
  XK_k = &H6B
  ''' <summary>
  ''' U+006C LATIN SMALL LETTER L
  ''' </summary>
  XK_l = &H6C
  ''' <summary>
  ''' U+006D LATIN SMALL LETTER M
  ''' </summary>
  XK_m = &H6D
  ''' <summary>
  ''' U+006E LATIN SMALL LETTER N
  ''' </summary>
  XK_n = &H6E
  ''' <summary>
  ''' U+006F LATIN SMALL LETTER O
  ''' </summary>
  XK_o = &H6F
  ''' <summary>
  ''' U+0070 LATIN SMALL LETTER P
  ''' </summary>
  XK_p = &H70
  ''' <summary>
  ''' U+0071 LATIN SMALL LETTER Q
  ''' </summary>
  XK_q = &H71
  ''' <summary>
  ''' U+0072 LATIN SMALL LETTER R
  ''' </summary>
  XK_r = &H72
  ''' <summary>
  ''' U+0073 LATIN SMALL LETTER S
  ''' </summary>
  XK_s = &H73
  ''' <summary>
  ''' U+0074 LATIN SMALL LETTER T
  ''' </summary>
  XK_t = &H74
  ''' <summary>
  ''' U+0075 LATIN SMALL LETTER U
  ''' </summary>
  XK_u = &H75
  ''' <summary>
  ''' U+0076 LATIN SMALL LETTER V
  ''' </summary>
  XK_v = &H76
  ''' <summary>
  ''' U+0077 LATIN SMALL LETTER W
  ''' </summary>
  XK_w = &H77
  ''' <summary>
  ''' U+0078 LATIN SMALL LETTER X
  ''' </summary>
  XK_x = &H78
  ''' <summary>
  ''' U+0079 LATIN SMALL LETTER Y
  ''' </summary>
  XK_y = &H79
  ''' <summary>
  ''' U+007A LATIN SMALL LETTER Z
  ''' </summary>
  XK_z = &H7A
  ''' <summary>
  ''' U+007B LEFT CURLY BRACKET
  ''' </summary>
  XK_braceleft = &H7B
  ''' <summary>
  ''' U+007C VERTICAL LINE
  ''' </summary>
  XK_bar = &H7C
  ''' <summary>
  ''' U+007D RIGHT CURLY BRACKET
  ''' </summary>
  XK_braceright = &H7D
  ''' <summary>
  ''' U+007E TILDE
  ''' </summary>
  XK_asciitilde = &H7E
End Enum

Public Enum XMapState
  IsUnmapped = 0
  IsUnviewable = 1
  IsViewable = 2
End Enum

<Flags()>
Public Enum XModMask
  ShiftMask = (1 << 0)
  LockMask = (1 << 1)
  ControlMask = (1 << 2)
  Mod1Mask = (1 << 3)
  Mod2Mask = (1 << 4)
  Mod3Mask = (1 << 5)
  Mod4Mask = (1 << 6)
  Mod5Mask = (1 << 7)
  AnyModifier = (1 << 15)
End Enum

Public Enum XMouseButton
  AnyButton = 0
  Button1 = 1
  Button2 = 2
  Button3 = 3
  Button4 = 4
  Button5 = 5
End Enum

Public Enum XPixmapErrorStatus
  XpmColorError = 1
  XpmSuccess = 0
  XpmOpenFailed = -1
  XpmFileInvalid = -2
  XpmNoMemory = -3
  XpmColorFailed = -4
End Enum

<Flags()>
Public Enum XPixmapValueMask
  XpmVisual = (1 << 0)
  XpmColormap = (1 << 1)
  XpmDepth = (1 << 2)
  XpmSize = (1 << 3)
  ' width & height 
  XpmHotspot = (1 << 4)
  ' x_hotspot & y_hotspot 
  XpmCharsPerPixel = (1 << 5)
  XpmColorSymbols = (1 << 6)
  XpmRgbFilename = (1 << 7)
  ' 3.2 backward compatibility code 
  XpmInfos = (1 << 8)
  XpmReturnInfos = XpmInfos
  ' end 3.2 bc 
  XpmReturnPixels = (1 << 9)
  XpmExtensions = (1 << 10)
  XpmReturnExtensions = XpmExtensions
  XpmExactColors = (1 << 11)
  XpmCloseness = (1 << 12)
  XpmRGBCloseness = (1 << 13)
  XpmColorKey = (1 << 14)
  XpmColorTable = (1 << 15)
  XpmReturnColorTable = XpmColorTable
  XpmReturnAllocPixels = (1 << 16)
  XpmAllocCloseColors = (1 << 17)
  XpmBitmapFormat = (1 << 18)
  XpmAllocColor = (1 << 19)
  XpmFreeColors = (1 << 20)
  XpmColorClosure = (1 << 21)
  ' XpmInfo value masks bits 
  XpmComments = XpmInfos
  XpmReturnComments = XpmComments
End Enum

Public Enum XShapeEventMask
  ShapeNotifyMask = (1 << 0)
  ShapeNotify = 0
End Enum

Public Enum XShapeKind
  ShapeBounding = 0
  ShapeClip = 1
  ShapeInput = 2
End Enum

Public Enum XShapeOperation
  ShapeSet = 0
  ShapeUnion = 1
  ShapeIntersect = 2
  ShapeSubtract = 3
  ShapeInvert = 4
End Enum

Public Enum XShapeReqType
  X_ShapeQueryVersion = 0
  X_ShapeRectangles = 1
  X_ShapeMask = 2
  X_ShapeCombine = 3
  X_ShapeOffset = 4
  X_ShapeQueryExtents = 5
  X_ShapeSelectInput = 6
  X_ShapeInputSelected = 7
  X_ShapeGetRectangles = 8
End Enum

<Flags()>
Public Enum XSizeHintFlags
  USPosition = (1 << 0)
  USSize = (1 << 1)
  PPosition = (1 << 2)
  PSize = (1 << 3)
  PMinSize = (1 << 4)
  PMaxSize = (1 << 5)
  PResizeInc = (1 << 6)
  PAspect = (1 << 7)
  PBaseSize = (1 << 8)
  PWinGravity = (1 << 9)
End Enum

Public Enum XSubwindowMode
  ClipByChildren = 0
  IncludeInferiors = 1
End Enum

<Flags()>
Public Enum XWindowAttributeFlags
  CWBackPixel = (1 << 1)
  CWBorderPixmap = (1 << 2)
  CWBorderPixel = (1 << 3)
  CWBitGravity = (1 << 4)
  CWWinGravity = (1 << 5)
  CWBackingStore = (1 << 6)
  CWBackingPlanes = (1 << 7)
  CWBackingPixel = (1 << 8)
  CWOverrideRedirect = (1 << 9)
  CWSaveUnder = (1 << 10)
  CWEventMask = (1 << 11)
  CWDontPropagate = (1 << 12)
  CWColormap = (1 << 13)
  CWCursor = (1 << 14)
End Enum

Public Enum XWindowState
  WithdrawnState = 0
  NormalState = 1
  IconicState = 3
End Enum

<Flags()>
Public Enum XWMHintFlags
  InputHint = (1 << 0)
  StateHint = (1 << 1)
  IconPixmapHint = (1 << 2)
  IconWindowHint = (1 << 3)
  IconPositionHint = (1 << 4)
  IconMaskHint = (1 << 5)
  WindowGroupHint = (1 << 6)
  AllHints = (InputHint Or StateHint Or IconPixmapHint Or IconWindowHint Or IconPositionHint Or IconMaskHint Or WindowGroupHint)
  XUrgencyHint = (1 << 8)
End Enum

Public Delegate Sub ShapeHandler(e As XShapeEvent, window As XWindow)
Public Delegate Sub KeyPressHandler(e As XKeyEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub KeyReleaseHandler(e As XKeyEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub ButtonPressHandler(e As XButtonEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub ButtonReleaseHandler(e As XButtonEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub ExposeHandler(e As XExposeEvent, window As XWindow)
Public Delegate Sub EnterNotifyHandler(e As XCrossingEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub LeaveNotifyHandler(e As XCrossingEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub MotionNotifyHandler(e As XMotionEvent, window As XWindow, root As XWindow, subwindow As XWindow)
Public Delegate Sub FocusInHandler(e As XFocusChangeEvent, window As XWindow)
Public Delegate Sub FocusOutHandler(e As XFocusChangeEvent, window As XWindow)
Public Delegate Sub KeymapNotifyHandler(e As XKeymapEvent, window As XWindow)
Public Delegate Sub GraphicsExposeHandler(e As XGraphicsExposeEvent, drawable As XWindow)
Public Delegate Sub NoExposeHandler(e As XNoExposeEvent, drawable As XWindow)
Public Delegate Sub VisibilityNotifyHandler(e As XVisibilityEvent, window As XWindow)
Public Delegate Sub CreateNotifyHandler(e As XCreateWindowEvent, parent As XWindow, window As XWindow)
Public Delegate Sub DestroyNotifyHandler(e As XDestroyWindowEvent, window As XWindow)
Public Delegate Sub UnmapNotifyHandler(e As XUnmapEvent, window As XWindow)
Public Delegate Sub MapNotifyHandler(e As XMapEvent, window As XWindow)
Public Delegate Sub MapRequestHandler(e As XMapRequestEvent, parent As XWindow, window As XWindow)
Public Delegate Sub ReparentNotifyHandler(e As XReparentEvent, parent As XWindow, window As XWindow)
Public Delegate Sub ConfigureNotifyHandler(e As XConfigureEvent, window As XWindow)
Public Delegate Sub ConfigureRequestHandler(e As XConfigureRequestEvent, window As XWindow)
Public Delegate Sub GravityNotifyHandler(e As XGravityEvent, window As XWindow)
Public Delegate Sub ResizeRequestHandler(e As XResizeRequestEvent, window As XWindow)
Public Delegate Sub CirculateNotifyHandler(e As XCirculateEvent, window As XWindow)
Public Delegate Sub CirculateRequestHandler(e As XCirculateRequestEvent, parent As XWindow, window As XWindow)
Public Delegate Sub PropertyNotifyHandler(e As XPropertyEvent, window As XWindow)
Public Delegate Sub SelectionClearHandler(e As XSelectionClearEvent, window As XWindow)
Public Delegate Sub SelectionRequestHandler(e As XSelectionRequestEvent, owner As XWindow, requestor As XWindow, target As XWindow)
Public Delegate Sub SelectionNotifyHandler(e As XSelectionEvent, requestor As XWindow, target As XWindow)
Public Delegate Sub ColormapNotifyHandler(e As XColormapEvent, window As XWindow)
Public Delegate Sub ClientMessageHandler(e As XClientMessageEvent, window As XWindow)
Public Delegate Sub MappingNotifyHandler(e As XMappingEvent, window As XWindow)

Friend Delegate Function XHandleXError(dpy As IntPtr, e As IntPtr) As Integer
Public Delegate Function ErrorHandler(e As XErrorEvent) As Integer