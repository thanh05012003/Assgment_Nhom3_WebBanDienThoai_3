

function getDistrict() {
    var provinceID = document.getElementById("provinceSelect").value;

    axios.get("https://online-gateway.ghn.vn/shiip/public-api/master-data/district?province_id=" + provinceID, {
        headers: {
            'token': 'a799ced2-febc-11ed-a967-deea53ba3605'
        }
    })
        .then(function (response) {
            console.log(response.data.data);
            var districtSlect = document.getElementById("districtSelect");
            districtSlect.innerHTML = "";
            for (var i = 0; i < response.data.data.length; i++) {
                var option = document.createElement("option");
                option.value = response.data.data[i].DistrictID;
                option.text = response.data.data[i].DistrictName;
                districtSlect.appendChild(option);
            }
            return response.json;
        })
        .catch(function (error) {
            console.log(error);
        })
}

function getWard() {
    var districtID = document.getElementById("districtSelect").value;

    axios.get("https://online-gateway.ghn.vn/shiip/public-api/master-data/ward?district_id=" + districtID, {
        headers: {
            'token': 'a799ced2-febc-11ed-a967-deea53ba3605'
        }
    })
        .then(function (response) {

            var wardSlect = document.getElementById("wardSelect");
            wardSlect.innerHTML = "";
            for (var i = 0; i < response.data.data.length; i++) {
                var option = document.createElement("option");
                option.value = response.data.data[i].WardCode;
                option.text = response.data.data[i].WardName;
                wardSlect.appendChild(option);
            }
            return response.json;
        })
        .catch(function (error) {
            console.log(error);
        })


    var wardCode = document.getElementById("wardSelect").value;

    axios.get("https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee?service_id=53321&insurance_value=100000000&coupon&to_ward_code=" + wardCode + "&to_district_id=" + districtID + "&from_district_id=3440&weight=1000&length=20&width=10&height=6", {
        headers: {
            'token': 'a799ced2-febc-11ed-a967-deea53ba3605',
            'shop_id': '4189088'
        }
    })
        .then(function (response) {
            console.log(response.data)
            var totalShip = document.getElementById("totalShip");
            totalShip.innerHTML = response.data.data.total.toLocaleString("vi-VN", {
                style: "currency",
                currency: "VND"
            });
        })

}
var bank = document.getElementById("banking");
bank.style.display = 'none';
function typeShip() {

    var tienMat = document.getElementById("directcheck");

    var bank = document.getElementById("banking");
    /* for (let i = 0; i < tienMat.length; i++) {*/
    if (tienMat.checked) {
        bank.style.display = 'none';
    } else {
        bank.style.display = '';
    }
}


