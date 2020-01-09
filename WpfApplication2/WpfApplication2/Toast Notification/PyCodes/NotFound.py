import sys
from win10toast import ToastNotifier
Argument = sys.argv
toaster = ToastNotifier()
toaster.show_toast("دستیار فارسی08", "نتیجه ای یافت نشد اتصال اینترنت خودرا بررسی کنید", "Icon (2).ico")