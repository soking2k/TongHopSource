<?php
namespace App\Http\Controllers; 
use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;
use Session;
use DB;
use illuminate\Http\Request;
use illuminate\Support\Facades\Redirect;
use App\Models\BlogModel;
 
class HomeController extends Controller {
    public function sanpham_list(){
        $value=DB::table('LoaiSP')->get();
        $value1=DB::table('SanPham')->get();

        return view('home')->with('viewdata', $value)->with('viewdata1', $value1);
    }
    public function sanpham_list_id(Request $request,$id){
        $value=DB::table('LoaiSP')->get();
        return view('home_SP')->with('viewdata', $value);
    }
    public function details(Request $request,$id){
        $data = DB::table('SanPham')->find($id); 
         return view('details',compact('data')); 
    }
}