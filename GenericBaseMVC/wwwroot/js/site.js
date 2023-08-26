$(".Theme-Control-option").on('click', function () {
    var val = $(this).val();
    ChangeTheme(val);
    console.log(val);
});

function ChangeTheme(themeName) {
var theme = $("#theme");
var newUrl = `/lib/bootstrap-themes/${themeName}/bootstrap.css`
console.log(newUrl, theme.attr('href'));
theme.attr('href', newUrl);
}

var emojis = {
    emojis : [
        { emoji: ["smile", "face-smile","&#x1F642"]},
        {emoji:["worried", "face-worried", "&#x1F62F" ]},
        {emoji:["sad" ,"face-sad", "&#x1F614" ]},
        {emoji:["sad_sweat", "face-sad-sweat", "&#x1F630" ]},
        {emoji:["laugh", "face-awesome", "&#x1F602" ]},
        {emoji:["lol" ,"face-laugh-squint", "&#x1F606" ]},
        {emoji:["smile_tear", "face-grin-tears","&#x1F605"]},
        {emoji:["rotf" ,"face-grin-squint-tears", "&#x1F923" ]},
        {emoji:["tongue_out", "face-grin-tongue", "&#x1F61B" ]},
        {emoji:["wink", "face-laugh-wink","&#x1F609"]},
        {emoji:["cry" ,"face-sad-cry","&#x1F62D"]},
        {emoji:["blush" ,"face-blush","&#x1F60A"]},
        {emoji:["straight", "face-meh","&#x1F610"]},
        {emoji:["crazy" ,"face-grin-tongue-wink","&#x1F61C"]},
        {emoji:["dead" ,"face-dizzy","&#x1F635"]},
        {emoji:["shocked", "face-flushed","&#x1F628"]},   
        {emoji:["love", "face-grin-hearts","&#x1F60D"]},
        {emoji:["weed" ,"cannabis","&#x1F340"]},
        {emoji:["flame" ,"fire","&#x1F525"]},
        {emoji:["drop" ,"droplet","&#x1F4A7"]},
        {emoji:["hand_peace", "hand-peace","&#x270C"]},
        {emoji:["hand_middle", "hand-middle-finger","&#x1F595"]},
        {emoji:["hand_wave" ,"hand-wave","&#x1F44B"]},
        {emoji:["hand_crossed", "hand-fingers-crossed","&#x1F91E"]},
        {emoji:["hand_fist" ,"hand-fist","&#x1F44A"]},
        {emoji:["hand_shake" ,"handshake","&#x1F91D"]},
        {emoji:["wow" ,"face-surprise","&#x1F632"]},
        {emoji:["kiss" ,"face-kiss-wink-heart","&#x1F618"]},
        {emoji:["cool" ,"face-sunglasses","&#x1F60E"]},
        {emoji:["evil" ,"face-smile-horns","&#x1F608"]},
        {emoji:["serious", "face-angry","&#x1F928"]},
        {emoji:["shock" ,"face-scream","&#x1F631"]},
        {emoji:["sigh" ,"face-sleepy","&#x1F62A"]},
        {emoji:["smirk", "face-smirking","&#x1F60F"]},
        {emoji:["no_emotion", "face-meh-blank","&#x1F636"]},
        {emoji:["no_talk", "face-zipper","&#x1F910"]},
        {emoji:["sick" ,"face-vomit","&#x1F92E"]},
]
};

function GetCodeFromFAClass(className) {
    var matchingCode
    emojis.emojis.forEach((details, index) => {
        var emojiDetails = details;
        faClassName = "fa-" +emojiDetails.emoji[1];
        emojiCode = emojiDetails.emoji[2];
        //console.log(className, faClassName, emojiCode, className == faClassName);
        if (className == faClassName) {
            matchingCode = emojiCode;
            return emojiCode;
        }
    });
    return matchingCode;

}

var selectedTheme = $("#Theme-Selected").val();
var numNotifications = $("#Settings-Notification-Num").val();

var adverts = $(".side-advert");

if (adverts.length > 1) {
    var leftAdvertPath = $("#Settings-Left-Side-Advert-Path").val();
    var leftAdvertDescription = $("#Settings-Left-Side-Advert-Description").val();
    var leftAdvertLink = $("#Settings-Left-Side-Advert-Hyperlink").val();
    var leftAdvertCaption = $("#Settings-Left-Side-Advert-Caption").val();
    var rightAdvertPath = $("#Settings-Right-Side-Advert-Path").val();
    var rightAdvertDescription = $("#Settings-Right-Side-Advert-Description").val();
    var rightAdvertLink = $("#Settings-Right-Side-Advert-Hyperlink").val();
    var rightAdvertCaption = $("#Settings-Right-Side-Advert-Caption").val();

    var leftAdvert = adverts[0];
    leftAdvert.children[0].src = "/" + leftAdvertPath.split("\\")[leftAdvertPath.split("\\").length - 1];
    leftAdvert.children[1].children[0].innerHTML = leftAdvertCaption;
    console.log("leftAdvert", leftAdvert);

    var rightAdvert = adverts[1];
    rightAdvert.children[0].src = "/" + rightAdvertPath.split("\\")[rightAdvertPath.split("\\").length - 1];
    rightAdvert.children[1].children[0].innerHTML = rightAdvertCaption;
    console.log("rightAdvert", rightAdvert);
}

console.log("side-advert", adverts);

if (selectedTheme == "" || selectedTheme == null) {
    selectedTheme = "Neon";
}

if (numNotifications == "" || numNotifications == null || numNotifications == 0) {
    numNotifications = 0;
    $("#notification-num-parent").hide();
}

$("#notifications-num").html(numNotifications);
ChangeTheme(selectedTheme);

console.log(selectedTheme);
