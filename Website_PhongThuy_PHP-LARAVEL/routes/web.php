<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::get('KhoaHoc',function(){
    return "Xin chao cac ban";

});

Route::get('DanPham/Laravel',function(){
    return "<h1>Trai Dat Nay La Cua Chung Minh</h1>";

});


Route::get('DanPham/{Ngay}',function($Ngay){

    echo "DAN PHAM:".$Ngay;
});

Route::get('DinhDanh',['as'=>'MyRoute',function(){
    return "<h1>Trai Dat Nay La Cua Chung Minh</h1>";

}]);

Route::get('GoiTen',function(){
    return redirect()->route('MyRoute');

});
Route::group(['middleware' => ['admin']], function () {
    Route::get('login', 'App\Http\Controllers\AdminController@index');
    Route::post('postLogin', 'App\Http\Controllers\AdminController@postLogin');
});

Route::get('users', 'App\Http\Controllers\BlogController@users_list')->name('users');
Route::get('create', 'App\Http\Controllers\BlogController@create')->name('create');
Route::post('insert', 'App\Http\Controllers\BlogController@insert')->name('insert');
Route::get('edit/{id}', 'App\Http\Controllers\BlogController@edit')->name('edit');
Route::post('update/{id}', 'App\Http\Controllers\BlogController@update')->name('update');
Route::get('delete/{id}', 'App\Http\Controllers\BlogController@delete')->name('delete');

// project phong thủy start
Route::get('home', 'App\Http\Controllers\HomeController@sanpham_list')->name('home');
Route::get('home/{id}', 'App\Http\Controllers\HomeController@sanpham_list_id')->name('home'); 
Route::get('details/{id}', 'App\Http\Controllers\HomeController@details')->name('details');

