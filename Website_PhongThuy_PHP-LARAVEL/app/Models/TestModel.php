<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class TestModel extends Model
{
    
    use HasFactory;
    protected $table = 'users';
    public $timestamps = false;
    protected $dateFormat = 'd-m-Y';

}

