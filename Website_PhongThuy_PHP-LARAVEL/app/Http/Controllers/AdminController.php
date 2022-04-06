<?php
namespace App\Http\Controllers;
use Illuminate\Support\Facades\Auth;
use Illuminate\Auth\AuthenticationException;
use Request;
use App\Models\UserAdmin;
use DB;
class AdminController extends Controller
{
public function index(){
   return view('admin');
}
public function postLogin(Request $request)
    {
       $user = DB::table('users')
                ->where('username','=', Request::get('username'))
                ->where('password','=',md5(Request::get('password')))
                ->get();
        print_r('<pre>');
        print_r($user);
        if (Auth::check()) {
            dd('Đăng nhập thành công');
        }
    }
}