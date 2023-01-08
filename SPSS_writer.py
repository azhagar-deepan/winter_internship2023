from tkinter import *  
import csv

def fn(l):
    Name    = l[0]
    Fvar    = l[3] 
    FRange  = l[4]
    BASE    = l[5]
    b_Range = l[6]
    var2    = l[7]
    var2_Range = l[8]
    A = l[9]
    v = [l[1],l[2]]
    match v:
        case ["Single","NO"]:
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nTEMP.\nSEL IF ~RANGE({BASE},{A}) OR SYS({BASE}).\nLIST RECORD.\nEXE."
        case ["Single","YES"]:
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nTEMP.\nSEL IF {Fvar}=1 AND (~RANGE({BASE},{A}) OR SYS({BASE})) | ({Fvar} NE 1 OR SYS({Fvar})) AND ~SYS({BASE}).\nLIST RECORD.\nEXE."
        case ["Single.Attr","NO"]:
            v[0] = "Single_Attribute"
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nCOMP ERR=0.\nDO REPEAT {BASE} = {b_Range}/\n{var2}={var2_Range}.\nIF (~RANGE({BASE},{A}) OR SYS({BASE})) ERR={var2}.\nEND REPEAT.\n\nTEMP.\nSEL IF ERR GE 1.\nLIST RECORD.\nEXE.\n\nDEL VAR ERR.\nexe."
        case ["Single.Attr","YES"]:
            v[0] = "Single_Attribute"
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nCOMP ERR=0.\nDO REPEAT {Fvar} = {FRange}/\n{BASE}={b_Range}/\n{var2}={var2_Range}.\nIF ({Fvar}=1 AND (~RANGE({BASE},{A}) OR SYS({BASE}))) | ({Fvar} NE 1 OR SYS({Fvar})) AND ~SYS({BASE}) ERR={var2}.\nEND REPEAT.\n\nTEMP.\nSEL IF ERR GE 1.\nLIST RECORD.\nEXE.\n\nDEL VAR ERR.\nexe.\n"
        case ["Multi","NO"]:
            v[0] = "Multi-Selectable"
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nCOMP ERR=0.\nDO REPEAT {BASE} = {b_Range}/\n{var2}= {var2_Range}.\nIF (~ANY({BASE},{A}) OR SYS({BASE})) ERR={var2}.\nEND REPEAT.\n\nTEMP.\nSEL IF ERR GE 1 | (SUM({b_Range})=0 OR SYS(SUM({b_Range}))) | ((SUM({b_Range}) GT 1) AND {list(b_Range.split())[2]}=1).\nLIST RECORD.\nEXE.\n\nDEL VAR ERR.\nexe.\n"
        case ["Multi","YES"]:
            v[0] = "Multi-Selectable"
            c = f"\n\n*****{Name}******.\n*#{v[0]} | Filter: {v[1]}.\n\nCOMP ERR=0.\nDO REPEAT {Fvar} = {FRange}/\n{BASE}={b_Range}/\n{var2}={var2_Range}.\nIF ({Fvar}=1 AND (~ANY({BASE},{A}) OR SYS({BASE}))) | ({Fvar} NE 1 OR SYS({Fvar})) AND ~SYS({BASE}) ERR={var2}.\nEND REPEAT.\n\nTEMP.\nSEL IF ERR GE 1 | {list(FRange.split())[0]}=1 AND (SUM({b_Range})=0 OR SYS(SUM({b_Range}))) | ({list(FRange.split())[0]} NE 1 OR SYS({list(FRange.split())[0]})) AND SUM({b_Range}) GE 1 | ((SUM({b_Range}) GT 1) AND {list(b_Range.split())[2]}=1).\nLIST RECORD.\nEXE.\n\nDEL VAR ERR.\nexe.\n"
    return c



base = Tk()  
base.geometry("300x300")
base.minsize(300, 300)
base.maxsize(300, 300)
base.title("SPSS Writer")  

lb1= Label(base, text="File Name: ", width=13, font=("arial",8))  
lb1.place(x=45, y=120)  
en1= Entry(base)  
en1.place(x=150, y=120)  
label= Label(base, text="Enter file name with extension (.csv)", font=('Helvetica',10))
label.pack()
def some():
    f =  open(en1.get(), mode ='r')
    csvFile = csv.reader(f)
    k = ""    
    for line in list(csvFile):
        k += fn(line)
    f = open("SPSS_CODE.txt", "w")
    f.write(k)
    f.close()
    label.config(text= "Done!\nCheck for file named 'SPSS_CODE' \ncreated in your current directory", font= ('Helvetica',10))

Button(base, text="OK", width=10,command= some).place(x=100,y=175)  
base.mainloop()

