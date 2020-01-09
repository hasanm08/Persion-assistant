import sys
from win10toast import ToastNotifier
Argument = sys.argv
toaster = ToastNotifier()
toaster.show_toast("دستیار فارسی08", "ایمیل ارسال شد", "Icon (2).ico")